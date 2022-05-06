﻿using ElectronNET.API.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace ElectronNET.API
{
    /// <summary>
    /// Render and control web pages.
    /// </summary>
    public class WebContents
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; private set; }

        /// <summary>
        /// Manage browser sessions, cookies, cache, proxy settings, etc.
        /// </summary>
        public Session Session { get; internal set; }

        /// <summary>
        /// Emitted when the renderer process crashes or is killed.
        /// </summary>
        public event Action<bool> OnCrashed
        {
            add
            {
                if (_crashed == null)
                {
                    BridgeConnector.Socket.On("webContents-crashed" + Id, (killed) =>
                    {
                        _crashed((bool)killed);
                    });

                    BridgeConnector.Socket.Emit("register-webContents-crashed", Id);
                }
                _crashed += value;
            }
            remove
            {
                _crashed -= value;

                if (_crashed == null)
                    BridgeConnector.Socket.Off("webContents-crashed" + Id);
            }
        }

        private event Action<bool> _crashed;

        /// <summary>
        /// Emitted when the navigation is done, i.e. the spinner of the tab has
        /// stopped spinning, and the onload event was dispatched.
        /// </summary>
        public event Action OnDidFinishLoad
        {
            add
            {
                if (_didFinishLoad == null)
                {
                    BridgeConnector.Socket.On("webContents-didFinishLoad" + Id, () =>
                    {
                        _didFinishLoad();
                    });

                    BridgeConnector.Socket.Emit("register-webContents-didFinishLoad", Id);
                }
                _didFinishLoad += value;
            }
            remove
            {
                _didFinishLoad -= value;

                if (_didFinishLoad == null)
                    BridgeConnector.Socket.Off("webContents-didFinishLoad" + Id);
            }
        }

        private event Action _didFinishLoad;

        internal WebContents(int id)
        {
            Id = id;
            Session = new Session(id);
        }

        /// <summary>
        /// Opens the devtools.
        /// </summary>
        public void OpenDevTools()
        {
            BridgeConnector.Socket.Emit("webContentsOpenDevTools", Id);
        }

        /// <summary>
        /// Opens the devtools.
        /// </summary>
        /// <param name="openDevToolsOptions"></param>
        public void OpenDevTools(OpenDevToolsOptions openDevToolsOptions)
        {
            BridgeConnector.Socket.Emit("webContentsOpenDevTools", Id, JObject.FromObject(openDevToolsOptions, _jsonSerializer));
        }

        /// <summary>
        /// Prints window's web page as PDF with Chromium's preview printing custom
        /// settings.The landscape will be ignored if @page CSS at-rule is used in the web page. 
        /// By default, an empty options will be regarded as: Use page-break-before: always; 
        /// CSS style to force to print to a new page.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns>success</returns>
        public Task<bool> PrintToPDFAsync(string path, PrintToPDFOptions options = null)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            BridgeConnector.Socket.On("webContents-printToPDF-completed", (success) =>
            {
                BridgeConnector.Socket.Off("webContents-printToPDF-completed");
                taskCompletionSource.SetResult((bool)success);
            });

            if(options == null)
            {
                BridgeConnector.Socket.Emit("webContents-printToPDF", Id, "", path);
            }
            else
            {
                BridgeConnector.Socket.Emit("webContents-printToPDF", Id, JObject.FromObject(options, _jsonSerializer), path);
            }

            return taskCompletionSource.Task;
        }

        /// <summary>
        /// Is used to get the Url of the loaded page.
        /// It's usefull if a web-server redirects you and you need to know where it redirects. For instance, It's useful in case of Implicit Authorization.
        /// </summary>
        /// <returns>URL of the loaded page</returns>
        public Task<string> GetUrl()
        {
            var taskCompletionSource = new TaskCompletionSource<string>();

            var eventString = "webContents-getUrl" + Id;
            BridgeConnector.Socket.On(eventString, (url) =>
            {
                BridgeConnector.Socket.Off(eventString);
                taskCompletionSource.SetResult((string)url);
            });

            BridgeConnector.Socket.Emit("webContents-getUrl", Id);

            return taskCompletionSource.Task;
        }
        
        private JsonSerializer _jsonSerializer = new JsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };
    }
}