﻿using ElectronNET.API.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronNET.API
{
    /// <summary>
    /// Control your application's event lifecycle.
    /// </summary>
    public sealed class App
    {
        /// <summary>
        /// Emitted when all windows have been closed.
        ///
        /// If you do not subscribe to this event and all windows are closed, 
        /// the default behavior is to quit the app; however, if you subscribe, 
        /// you control whether the app quits or not.If the user pressed Cmd + Q, 
        /// or the developer called app.quit(), Electron will first try to close 
        /// all the windows and then emit the will-quit event, and in this case the
        /// window-all-closed event would not be emitted.
        /// </summary>
        public event Action WindowAllClosed
        {
            add
            {
                if (_windowAllClosed == null)
                {
                    BridgeConnector.Socket.On("app-window-all-closed" + GetHashCode(), () =>
                    {
                        if (!Electron.WindowManager.IsQuitOnWindowAllClosed)
                        {
                            _windowAllClosed();
                        }
                    });

                    BridgeConnector.Socket.Emit("register-app-window-all-closed-event", GetHashCode());
                }
                _windowAllClosed += value;
            }
            remove
            {
                _windowAllClosed -= value;

                if(_windowAllClosed == null)
                    BridgeConnector.Socket.Off("app-window-all-closed" + GetHashCode());
            }
        }

        private event Action _windowAllClosed;

        /// <summary>
        /// Emitted before the application starts closing its windows. 
        /// 
        /// Note: If application quit was initiated by autoUpdater.quitAndInstall() then before-quit is emitted after
        /// emitting close event on all windows and closing them.
        /// </summary>
        public event Func<QuitEventArgs, Task> BeforeQuit
        {
            add
            {
                if (_beforeQuit == null)
                {
                    BridgeConnector.Socket.On("app-before-quit" + GetHashCode(), async () =>
                    {
                        await _beforeQuit(new QuitEventArgs());

                        if (_preventQuit)
                        {
                            _preventQuit = false;
                        }
                        else
                        {
                            if (_willQuit == null && _quitting == null)
                            {
                                Exit();
                            }
                            else if (_willQuit != null)
                            {
                                await _willQuit(new QuitEventArgs());

                                if (_preventQuit)
                                {
                                    _preventQuit = false;
                                }
                                else
                                {
                                    if (_quitting == null)
                                    {
                                        Exit();
                                    }
                                    else
                                    {
                                        await _quitting();
                                        Exit();
                                    }
                                }
                            }
                            else if (_quitting != null)
                            {
                                await _quitting();
                                Exit();
                            }
                        }
                    });

                    BridgeConnector.Socket.Emit("register-app-before-quit-event", GetHashCode());
                }
                _beforeQuit += value;
            }
            remove
            {
                _beforeQuit -= value;

                if (_beforeQuit == null)
                    BridgeConnector.Socket.Off("app-before-quit" + GetHashCode());
            }
        }

        private event Func<QuitEventArgs, Task> _beforeQuit;

        /// <summary>
        /// Emitted when all windows have been closed and the application will quit. 
        ///
        /// See the description of the window-all-closed event for the differences between the will-quit and 
        /// window-all-closed events.
        /// </summary>
        public event Func<QuitEventArgs, Task> WillQuit
        {
            add
            {
                if (_willQuit == null)
                {
                    BridgeConnector.Socket.On("app-will-quit" + GetHashCode(), async () =>
                    {
                        await _willQuit(new QuitEventArgs());

                        if (_preventQuit)
                        {
                            _preventQuit = false;
                        }
                        else
                        {
                            if (_quitting == null)
                            {
                                Exit();
                            }
                            else
                            {
                                await _quitting();
                                Exit();
                            }
                        }
                    });

                    BridgeConnector.Socket.Emit("register-app-will-quit-event", GetHashCode());
                }
                _willQuit += value;
            }
            remove
            {
                _willQuit -= value;

                if (_willQuit == null)
                    BridgeConnector.Socket.Off("app-will-quit" + GetHashCode());
            }
        }

        private event Func<QuitEventArgs, Task> _willQuit;

        /// <summary>
        /// Emitted when the application is quitting.
        /// </summary>
        public event Func<Task> Quitting
        {
            add
            {
                if (_quitting == null)
                {
                    BridgeConnector.Socket.On("app-will-quit" + GetHashCode() + "quitting", async () =>
                    {
                        if(_willQuit == null)
                        {
                            await _quitting();
                            Exit();
                        }
                    });

                    BridgeConnector.Socket.Emit("register-app-will-quit-event", GetHashCode() + "quitting");
                }
                _quitting += value;
            }
            remove
            {
                _quitting -= value;

                if (_quitting == null)
                    BridgeConnector.Socket.Off("app-will-quit" + GetHashCode() + "quitting");
            }
        }

        private event Func<Task> _quitting;

        /// <summary>
        /// Emitted when a BrowserWindow gets blurred.
        /// </summary>
        public event Action BrowserWindowBlur
        {
            add
            {
                if (_browserWindowBlur == null)
                {
                    BridgeConnector.Socket.On("app-browser-window-blur" + GetHashCode(), () =>
                    {
                        _browserWindowBlur();
                    });

                    BridgeConnector.Socket.Emit("register-app-browser-window-blur-event", GetHashCode());
                }
                _browserWindowBlur += value;
            }
            remove
            {
                _browserWindowBlur -= value;

                if (_browserWindowBlur == null)
                    BridgeConnector.Socket.Off("app-browser-window-blur" + GetHashCode());
            }
        }

        private event Action _browserWindowBlur;

        /// <summary>
        /// Emitted when a BrowserWindow gets focused.
        /// </summary>
        public event Action BrowserWindowFocus
        {
            add
            {
                if (_browserWindowFocus == null)
                {
                    BridgeConnector.Socket.On("app-browser-window-focus" + GetHashCode(), () =>
                    {
                        _browserWindowFocus();
                    });

                    BridgeConnector.Socket.Emit("register-app-browser-window-focus-event", GetHashCode());
                }
                _browserWindowFocus += value;
            }
            remove
            {
                _browserWindowFocus -= value;

                if (_browserWindowFocus == null)
                    BridgeConnector.Socket.Off("app-browser-window-focus" + GetHashCode());
            }
        }

        private event Action _browserWindowFocus;

        /// <summary>
        /// Emitted when a new BrowserWindow is created.
        /// </summary>
        public event Action BrowserWindowCreated
        {
            add
            {
                if (_browserWindowCreated == null)
                {
                    BridgeConnector.Socket.On("app-browser-window-created" + GetHashCode(), () =>
                    {
                        _browserWindowCreated();
                    });

                    BridgeConnector.Socket.Emit("register-app-browser-window-created-event", GetHashCode());
                }
                _browserWindowCreated += value;
            }
            remove
            {
                _browserWindowCreated -= value;

                if (_browserWindowCreated == null)
                    BridgeConnector.Socket.Off("app-browser-window-created" + GetHashCode());
            }
        }

        private event Action _browserWindowCreated;

        /// <summary>
        /// Emitted when a new webContents is created.
        /// </summary>
        public event Action WebContentsCreated
        {
            add
            {
                if (_webContentsCreated == null)
                {
                    BridgeConnector.Socket.On("app-web-contents-created" + GetHashCode(), () =>
                    {
                        _webContentsCreated();
                    });

                    BridgeConnector.Socket.Emit("register-app-web-contents-created-event", GetHashCode());
                }
                _webContentsCreated += value;
            }
            remove
            {
                _webContentsCreated -= value;

                if (_webContentsCreated == null)
                    BridgeConnector.Socket.Off("app-web-contents-created" + GetHashCode());
            }
        }

        private event Action _webContentsCreated;

        /// <summary>
        /// Emitted when Chrome’s accessibility support changes. 
        /// This event fires when assistive technologies, such as screen readers, are enabled or disabled. 
        /// See https://www.chromium.org/developers/design-documents/accessibility for more details.
        /// </summary>
        public event Action<bool> AccessibilitySupportChanged
        {
            add
            {
                if (_accessibilitySupportChanged == null)
                {
                    BridgeConnector.Socket.On("app-accessibility-support-changed" + GetHashCode(), (state) =>
                    {
                        _accessibilitySupportChanged((bool)state);
                    });

                    BridgeConnector.Socket.Emit("register-app-accessibility-support-changed-event", GetHashCode());
                }
                _accessibilitySupportChanged += value;
            }
            remove
            {
                _accessibilitySupportChanged -= value;

                if (_accessibilitySupportChanged == null)
                    BridgeConnector.Socket.Off("app-accessibility-support-changed" + GetHashCode());
            }
        }

        private event Action<bool> _accessibilitySupportChanged;

        internal App() 
        {
            CommandLine = new CommandLine();
        }

        internal static App Instance
        {
            get
            {
                if (_app == null)
                {
                    lock (_syncRoot)
                    {
                        if(_app == null)
                        {
                            _app = new App();
                        }
                    }
                }

                return _app;
            }
        }

        private static App _app;
        private static object _syncRoot = new object();

        private JsonSerializer _jsonSerializer = new JsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        /// <summary>
        /// Try to close all windows. The before-quit event will be emitted first. If all
        /// windows are successfully closed, the will-quit event will be emitted and by
        /// default the application will terminate. This method guarantees that all
        /// beforeunload and unload event handlers are correctly executed. It is possible
        /// that a window cancels the quitting by returning false in the beforeunload event
        /// handler.
        /// </summary>
        public void Quit()
        {
            BridgeConnector.Socket.Emit("appQuit");
        }

        /// <summary>
        /// All windows will be closed immediately without asking user and 
        /// the before-quit and will-quit events will not be emitted.
        /// </summary>
        /// <param name="exitCode">Exits immediately with exitCode. exitCode defaults to 0.</param>
        public void Exit(int exitCode = 0)
        {
            BridgeConnector.Socket.Emit("appExit", exitCode);
        }

        /// <summary>
        /// Relaunches the app when current instance exits. By default the new instance will
        /// use the same working directory and command line arguments with current instance.
        /// When args is specified, the args will be passed as command line arguments
        /// instead. When execPath is specified, the execPath will be executed for relaunch
        /// instead of current app. Note that this method does not quit the app when
        /// executed, you have to call app.quit or app.exit after calling app.relaunch to
        /// make the app restart. When app.relaunch is called for multiple times, multiple
        /// instances will be started after current instance exited.
        /// </summary>
        public void Relaunch()
        {
            BridgeConnector.Socket.Emit("appRelaunch");
        }

        /// <summary>
        /// Relaunches the app when current instance exits. By default the new instance will
        /// use the same working directory and command line arguments with current instance.
        /// When args is specified, the args will be passed as command line arguments
        /// instead. When execPath is specified, the execPath will be executed for relaunch
        /// instead of current app. Note that this method does not quit the app when
        /// executed, you have to call app.quit or app.exit after calling app.relaunch to
        /// make the app restart. When app.relaunch is called for multiple times, multiple
        /// instances will be started after current instance exited.
        /// </summary>
        /// <param name="relaunchOptions"></param>
        public void Relaunch(RelaunchOptions relaunchOptions)
        {
            BridgeConnector.Socket.Emit("appRelaunch", JObject.FromObject(relaunchOptions, _jsonSerializer));
        }

        /// <summary>
        /// On Linux, focuses on the first visible window. On macOS, makes the application
        /// the active app.On Windows, focuses on the application's first window.
        /// </summary>
        public void Focus()
        {
            BridgeConnector.Socket.Emit("appFocus");
        }

        /// <summary>
        /// Hides all application windows without minimizing them.
        /// </summary>
        public void Hide()
        {
            BridgeConnector.Socket.Emit("appHide");
        }

        /// <summary>
        /// Shows application windows after they were hidden. Does not automatically focus them.
        /// </summary>
        public void Show()
        {
            BridgeConnector.Socket.Emit("appShow");
        }

        /// <summary>
        /// The current application directory.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAppPathAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using(cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetAppPathCompleted", (path) =>
                {
                    BridgeConnector.Socket.Off("appGetAppPathCompleted");
                    taskCompletionSource.SetResult(path.ToString());
                });

                BridgeConnector.Socket.Emit("appGetAppPath");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }            
        }

        /// <summary>
        /// You can request the following paths by the name.
        /// </summary>
        /// <returns>A path to a special directory or file associated with name.</returns>
        public async Task<string> GetPathAsync(PathName pathName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using(cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetPathCompleted", (path) =>
                {
                    BridgeConnector.Socket.Off("appGetPathCompleted");

                    taskCompletionSource.SetResult(path.ToString());
                });

                BridgeConnector.Socket.Emit("appGetPath", pathName.ToString());

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }  
        }


        /// <summary>
        /// Overrides the path to a special directory or file associated with name. If the
        /// path specifies a directory that does not exist, the directory will be created by
        /// this method.On failure an Error is thrown.You can only override paths of a
        /// name defined in app.getPath. By default, web pages' cookies and caches will be
        /// stored under the userData directory.If you want to change this location, you
        /// have to override the userData path before the ready event of the app module is emitted.
        /// </summary>
        public void SetPath(string name, string path)
        {
            BridgeConnector.Socket.Emit("appSetPath", name, path);
        }

        /// <summary>
        /// The version of the loaded application. 
        /// If no version is found in the application’s package.json file, 
        /// the version of the current bundle or executable is returned.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetVersionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using(cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetVersionCompleted", (version) =>
                {
                    BridgeConnector.Socket.Off("appGetVersionCompleted");
                    taskCompletionSource.SetResult(version.ToString());
                });

                BridgeConnector.Socket.Emit("appGetVersion");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Usually the name field of package.json is a short lowercased name, according to
        /// the npm modules spec. You should usually also specify a productName field, which
        /// is your application's full capitalized name, and which will be preferred over
        /// name by Electron.
        /// </summary>
        /// <returns>The current application’s name, which is the name in the application’s package.json file.</returns>
        public async Task<string> GetNameAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using(cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetNameCompleted", (name) =>
                {
                    BridgeConnector.Socket.Off("appGetNameCompleted");
                    taskCompletionSource.SetResult(name.ToString());
                });

                BridgeConnector.Socket.Emit("appGetName");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Overrides the current application's name.
        /// </summary>
        /// <param name="name">Application's name</param>
        public void SetName(string name)
        {
            BridgeConnector.Socket.Emit("appSetName", name);
        }

        /// <summary>
        /// The current application locale.
        ///  Note: When distributing your packaged app, you have to also ship the locales
        ///  folder.Note: On Windows you have to call it after the ready events gets emitted.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetLocaleAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetLocaleCompleted", (local) =>
                {
                    BridgeConnector.Socket.Off("appGetLocaleCompleted");
                    taskCompletionSource.SetResult(local.ToString());
                });

                BridgeConnector.Socket.Emit("appGetLocale");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Adds path to the recent documents list. This list is managed by the OS. On
        /// Windows you can visit the list from the task bar, and on macOS you can visit it
        /// from dock menu.
        /// </summary>
        public void AddRecentDocument(string path)
        {
            BridgeConnector.Socket.Emit("appAddRecentDocument", path);
        }

        /// <summary>
        /// Clears the recent documents list.
        /// </summary>
        public void ClearRecentDocuments()
        {
            BridgeConnector.Socket.Emit("appClearRecentDocuments");
        }

        /// <summary>
        /// This method sets the current executable as the default handler for a protocol
        /// (aka URI scheme). It allows you to integrate your app deeper into the operating
        /// system.Once registered, all links with your-protocol:// will be opened with the
        /// current executable. The whole link, including protocol, will be passed to your
        /// application as a parameter. On Windows you can provide optional parameters path,
        /// the path to your executable, and args, an array of arguments to be passed to
        /// your executable when it launches.Note: On macOS, you can only register
        /// protocols that have been added to your app's info.plist, which can not be
        /// modified at runtime.You can however change the file with a simple text editor
        /// or script during build time. Please refer to Apple's documentation for details.
        /// The API uses the Windows Registry and LSSetDefaultHandlerForURLScheme
        /// internally.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://. 
        /// If you want your app to handle electron:// links, 
        /// call this method with electron as the parameter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> SetAsDefaultProtocolClientAsync(string protocol, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appSetAsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appSetAsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appSetAsDefaultProtocolClient", protocol);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method sets the current executable as the default handler for a protocol
        /// (aka URI scheme). It allows you to integrate your app deeper into the operating
        /// system.Once registered, all links with your-protocol:// will be opened with the
        /// current executable. The whole link, including protocol, will be passed to your
        /// application as a parameter. On Windows you can provide optional parameters path,
        /// the path to your executable, and args, an array of arguments to be passed to
        /// your executable when it launches.Note: On macOS, you can only register
        /// protocols that have been added to your app's info.plist, which can not be
        /// modified at runtime.You can however change the file with a simple text editor
        /// or script during build time. Please refer to Apple's documentation for details.
        /// The API uses the Windows Registry and LSSetDefaultHandlerForURLScheme
        /// internally.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://. 
        /// If you want your app to handle electron:// links, 
        /// call this method with electron as the parameter.</param>
        /// <param name="path">Defaults to process.execPath</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> SetAsDefaultProtocolClientAsync(string protocol, string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appSetAsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appSetAsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appSetAsDefaultProtocolClient", protocol, path);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method sets the current executable as the default handler for a protocol
        /// (aka URI scheme). It allows you to integrate your app deeper into the operating
        /// system.Once registered, all links with your-protocol:// will be opened with the
        /// current executable. The whole link, including protocol, will be passed to your
        /// application as a parameter. On Windows you can provide optional parameters path,
        /// the path to your executable, and args, an array of arguments to be passed to
        /// your executable when it launches.Note: On macOS, you can only register
        /// protocols that have been added to your app's info.plist, which can not be
        /// modified at runtime.You can however change the file with a simple text editor
        /// or script during build time. Please refer to Apple's documentation for details.
        /// The API uses the Windows Registry and LSSetDefaultHandlerForURLScheme
        /// internally.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://. 
        /// If you want your app to handle electron:// links, 
        /// call this method with electron as the parameter.</param>
        /// <param name="path">Defaults to process.execPath</param>
        /// <param name="args">Defaults to an empty array</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> SetAsDefaultProtocolClientAsync(string protocol, string path, string[] args, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appSetAsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appSetAsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appSetAsDefaultProtocolClient", protocol, path, args);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method checks if the current executable as the default handler for a
        /// protocol(aka URI scheme). If so, it will remove the app as the default handler.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> RemoveAsDefaultProtocolClientAsync(string protocol, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appRemoveAsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appRemoveAsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appRemoveAsDefaultProtocolClient", protocol);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method checks if the current executable as the default handler for a
        /// protocol(aka URI scheme). If so, it will remove the app as the default handler.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://.</param>
        /// <param name="path">Defaults to process.execPath.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> RemoveAsDefaultProtocolClientAsync(string protocol, string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appRemoveAsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appRemoveAsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appRemoveAsDefaultProtocolClient", protocol, path);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method checks if the current executable as the default handler for a
        /// protocol(aka URI scheme). If so, it will remove the app as the default handler.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://.</param>
        /// <param name="path">Defaults to process.execPath.</param>
        /// <param name="args">Defaults to an empty array.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> RemoveAsDefaultProtocolClientAsync(string protocol, string path, string[] args, CancellationToken cancellationToken = default(CancellationToken))
        {           
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appRemoveAsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appRemoveAsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appRemoveAsDefaultProtocolClient", protocol, path, args);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method checks if the current executable is the default handler for a
        /// protocol(aka URI scheme). If so, it will return true. Otherwise, it will return
        /// false. Note: On macOS, you can use this method to check if the app has been
        /// registered as the default protocol handler for a protocol.You can also verify
        /// this by checking ~/Library/Preferences/com.apple.LaunchServices.plist on the
        /// macOS machine.Please refer to Apple's documentation for details. The API uses
        /// the Windows Registry and LSCopyDefaultHandlerForURLScheme internally.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns Boolean</returns>
        public async Task<bool> IsDefaultProtocolClientAsync(string protocol, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appIsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appIsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appIsDefaultProtocolClient", protocol);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }            
        }

        /// <summary>
        /// This method checks if the current executable is the default handler for a
        /// protocol(aka URI scheme). If so, it will return true. Otherwise, it will return
        /// false. Note: On macOS, you can use this method to check if the app has been
        /// registered as the default protocol handler for a protocol.You can also verify
        /// this by checking ~/Library/Preferences/com.apple.LaunchServices.plist on the
        /// macOS machine.Please refer to Apple's documentation for details. The API uses
        /// the Windows Registry and LSCopyDefaultHandlerForURLScheme internally.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://.</param>
        /// <param name="path">Defaults to process.execPath.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns Boolean</returns>
        public async Task<bool> IsDefaultProtocolClientAsync(string protocol, string path, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appIsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appIsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appIsDefaultProtocolClient", protocol, path);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// This method checks if the current executable is the default handler for a
        /// protocol(aka URI scheme). If so, it will return true. Otherwise, it will return
        /// false. Note: On macOS, you can use this method to check if the app has been
        /// registered as the default protocol handler for a protocol.You can also verify
        /// this by checking ~/Library/Preferences/com.apple.LaunchServices.plist on the
        /// macOS machine.Please refer to Apple's documentation for details. The API uses
        /// the Windows Registry and LSCopyDefaultHandlerForURLScheme internally.
        /// </summary>
        /// <param name="protocol">The name of your protocol, without ://.</param>
        /// <param name="path">Defaults to process.execPath.</param>
        /// <param name="args">Defaults to an empty array.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns Boolean</returns>
        public async Task<bool> IsDefaultProtocolClientAsync(string protocol, string path, string[] args, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appIsDefaultProtocolClientCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appIsDefaultProtocolClientCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appIsDefaultProtocolClient", protocol, path, args);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Adds tasks to the Tasks category of the JumpList on Windows. tasks is an array
        /// of Task objects.Note: If you'd like to customize the Jump List even more use
        /// app.setJumpList(categories) instead.
        /// </summary>
        /// <param name="userTasks">Array of Task objects.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> SetUserTasksAsync(UserTask[] userTasks, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appSetUserTasksCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appSetUserTasksCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appSetUserTasks", JObject.FromObject(userTasks, _jsonSerializer));

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Jump List settings for the application.
        /// </summary>
        /// <returns></returns>
        public async Task<JumpListSettings> GetJumpListSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<JumpListSettings>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetJumpListSettingsCompleted", (jumplistSettings) =>
                {
                    BridgeConnector.Socket.Off("appGetJumpListSettingsCompleted");
                    taskCompletionSource.SetResult(JObject.Parse(jumplistSettings.ToString()).ToObject<JumpListSettings>());
                });

                BridgeConnector.Socket.Emit("appGetJumpListSettings");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sets or removes a custom Jump List for the application, and returns one of the
        /// following strings: If categories is null the previously set custom Jump List(if
        /// any) will be replaced by the standard Jump List for the app(managed by
        /// Windows). Note: If a JumpListCategory object has neither the type nor the name
        /// property set then its type is assumed to be tasks.If the name property is set
        /// but the type property is omitted then the type is assumed to be custom. Note:
        /// Users can remove items from custom categories, and Windows will not allow a
        /// removed item to be added back into a custom category until after the next
        /// successful call to app.setJumpList(categories). Any attempt to re-add a removed
        /// item to a custom category earlier than that will result in the entire custom
        /// category being omitted from the Jump List. The list of removed items can be
        /// obtained using app.getJumpListSettings(). 
        /// </summary>
        /// <param name="jumpListCategories"></param>
        public void SetJumpList(JumpListCategory[] jumpListCategories)
        {
            BridgeConnector.Socket.Emit("appSetJumpList", JObject.FromObject(jumpListCategories, _jsonSerializer));
        }

        /// <summary>
        /// This method makes your application a Single Instance Application - instead of
        /// allowing multiple instances of your app to run, this will ensure that only a
        /// single instance of your app is running, and other instances signal this instance
        /// and exit.callback will be called by the first instance with callback(argv,
        /// workingDirectory) when a second instance has been executed.argv is an Array of
        /// the second instance's command line arguments, and workingDirectory is its
        /// current working directory.Usually applications respond to this by making their
        /// primary window focused and non-minimized.The callback is guaranteed to be
        /// executed after the ready event of app gets emitted.This method returns false if
        /// your process is the primary instance of the application and your app should
        /// continue loading.And returns true if your process has sent its parameters to
        /// another instance, and you should immediately quit.On macOS the system enforces
        /// single instance automatically when users try to open a second instance of your
        /// app in Finder, and the open-file and open-url events will be emitted for that.
        /// However when users start your app in command line the system's single instance
        /// mechanism will be bypassed and you have to use this method to ensure single
        /// instance.
        /// </summary>
        /// <param name="newInstanceOpened">Lambda with an array of the second instance’s command line arguments.
        /// The second parameter is the working directory path.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>This method returns false if your process is the primary instance of 
        /// the application and your app should continue loading. And returns true if your 
        /// process has sent its parameters to another instance, and you should immediately quit.</returns>
        public async Task<bool> RequestSingleInstanceLockAsync(Action<string[], string> newInstanceOpened, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appRequestSingleInstanceLockCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appRequestSingleInstanceLockCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Off("secondInstance");
                BridgeConnector.Socket.On("secondInstance", (result) =>
                {
                    JArray results = (JArray)result;
                    string[] args = results.First.ToObject<string[]>();
                    string workdirectory = results.Last.ToObject<string>();

                    newInstanceOpened(args, workdirectory);
                });

                BridgeConnector.Socket.Emit("appRequestSingleInstanceLock");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Releases all locks that were created by makeSingleInstance. This will allow
        /// multiple instances of the application to once again run side by side.
        /// </summary>
        public void ReleaseSingleInstanceLock()
        {
            BridgeConnector.Socket.Emit("appReleaseSingleInstanceLock");
        }

        /// <summary>
        /// Creates an NSUserActivity and sets it as the current activity. The activity is
        /// eligible for Handoff to another device afterward.
        /// </summary>
        /// <param name="type">Uniquely identifies the activity. Maps to NSUserActivity.activityType.</param>
        /// <param name="userInfo">App-specific state to store for use by another device.</param>
        public void SetUserActivity(string type, object userInfo)
        {
            BridgeConnector.Socket.Emit("appSetUserActivity", type, userInfo);
        }

        /// <summary>
        /// Creates an NSUserActivity and sets it as the current activity. The activity is
        /// eligible for Handoff to another device afterward.
        /// </summary>
        /// <param name="type">Uniquely identifies the activity. Maps to NSUserActivity.activityType.</param>
        /// <param name="userInfo">App-specific state to store for use by another device.</param>
        /// <param name="webpageURL">The webpage to load in a browser if no suitable app is installed on the resuming device. The scheme must be http or https.</param>
        public void SetUserActivity(string type, object userInfo, string webpageURL)
        {
            BridgeConnector.Socket.Emit("appSetUserActivity", type, userInfo, webpageURL);
        }

        /// <summary>
        /// The type of the currently running activity.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetCurrentActivityTypeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetCurrentActivityTypeCompleted", (activityType) =>
                {
                    BridgeConnector.Socket.Off("appGetCurrentActivityTypeCompleted");
                    taskCompletionSource.SetResult(activityType.ToString());
                });

                BridgeConnector.Socket.Emit("appGetCurrentActivityType");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Changes the Application User Model ID to id.
        /// </summary>
        /// <param name="id"></param>
        public void SetAppUserModelId(string id)
        {
            BridgeConnector.Socket.Emit("appSetAppUserModelId", id);
        }

        /// <summary>
        /// Imports the certificate in pkcs12 format into the platform certificate store.
        /// callback is called with the result of import operation, a value of 0 indicates
        /// success while any other value indicates failure according to chromium net_error_list.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Result of import. Value of 0 indicates success.</returns>
        public async Task<int> ImportCertificateAsync(ImportCertificateOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<int>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appImportCertificateCompleted", (result) =>
                {
                    BridgeConnector.Socket.Off("appImportCertificateCompleted");
                    taskCompletionSource.SetResult((int)result);
                });

                BridgeConnector.Socket.Emit("appImportCertificate", JObject.FromObject(options, _jsonSerializer));

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Memory and cpu usage statistics of all the processes associated with the app.
        /// </summary>
        /// <returns>Array of ProcessMetric objects that correspond to memory and cpu usage
        /// statistics of all the processes associated with the app.</returns>
        public async Task<ProcessMetric[]> GetAppMetricsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<ProcessMetric[]>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetAppMetricsCompleted", (result) =>
                {
                    BridgeConnector.Socket.Off("appGetAppMetricsCompleted");
                    var processMetrics = ((JArray)result).ToObject<ProcessMetric[]>();

                    taskCompletionSource.SetResult(processMetrics);
                });

                BridgeConnector.Socket.Emit("appGetAppMetrics");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// The Graphics Feature Status from chrome://gpu/.
        /// </summary>
        /// <returns></returns>
        public async Task<GPUFeatureStatus> GetGpuFeatureStatusAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<GPUFeatureStatus>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetGpuFeatureStatusCompleted", (result) =>
                {
                    BridgeConnector.Socket.Off("appGetGpuFeatureStatusCompleted");
                    var gpuFeatureStatus = ((JObject)result).ToObject<GPUFeatureStatus>();

                    taskCompletionSource.SetResult(gpuFeatureStatus);
                });

                BridgeConnector.Socket.Emit("appGetGpuFeatureStatus");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sets the counter badge for current app. Setting the count to 0 will hide the
        /// badge. On macOS it shows on the dock icon. On Linux it only works for Unity
        /// launcher, Note: Unity launcher requires the existence of a.desktop file to
        /// work, for more information please read Desktop Environment Integration.
        /// </summary>
        /// <returns>Whether the call succeeded.</returns>
        public async Task<bool> SetBadgeCountAsync(int count, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appSetBadgeCountCompleted", (success) =>
                {
                    BridgeConnector.Socket.Off("appSetBadgeCountCompleted");
                    taskCompletionSource.SetResult((bool)success);
                });

                BridgeConnector.Socket.Emit("appSetBadgeCount", count);

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// The current value displayed in the counter badge.
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetBadgeCountAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<int>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetBadgeCountCompleted", (count) =>
                {
                    BridgeConnector.Socket.Off("appGetBadgeCountCompleted");
                    taskCompletionSource.SetResult((int)count);
                });

                BridgeConnector.Socket.Emit("appGetBadgeCount");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Manipulate the command line arguments for your app that Chromium reads.
        /// </summary>
        public CommandLine CommandLine { get; internal set; }

        /// <summary>
        /// Whether the current desktop environment is Unity launcher.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsUnityRunningAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appIsUnityRunningCompleted", (isUnityRunning) =>
                {
                    BridgeConnector.Socket.Off("appIsUnityRunningCompleted");
                    taskCompletionSource.SetResult((bool)isUnityRunning);
                });

                BridgeConnector.Socket.Emit("appIsUnityRunning");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// If you provided path and args options to app.setLoginItemSettings then you need
        /// to pass the same arguments here for openAtLogin to be set correctly. Note: This
        /// API has no effect on MAS builds.
        /// </summary>
        /// <returns></returns>
        public async Task<LoginItemSettings> GetLoginItemSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<LoginItemSettings>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetLoginItemSettingsCompleted", (loginItemSettings) =>
                {
                    BridgeConnector.Socket.Off("appGetLoginItemSettingsCompleted");
                    taskCompletionSource.SetResult((LoginItemSettings)loginItemSettings);
                });

                BridgeConnector.Socket.Emit("appGetLoginItemSettings");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// If you provided path and args options to app.setLoginItemSettings then you need
        /// to pass the same arguments here for openAtLogin to be set correctly. Note: This
        /// API has no effect on MAS builds.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<LoginItemSettings> GetLoginItemSettingsAsync(LoginItemSettingsOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<LoginItemSettings>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appGetLoginItemSettingsCompleted", (loginItemSettings) =>
                {
                    BridgeConnector.Socket.Off("appGetLoginItemSettingsCompleted");
                    taskCompletionSource.SetResult((LoginItemSettings)loginItemSettings);
                });

                BridgeConnector.Socket.Emit("appGetLoginItemSettings", JObject.FromObject(options, _jsonSerializer));

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Set the app's login item settings. To work with Electron's autoUpdater on
        /// Windows, which uses Squirrel, you'll want to set the launch path to Update.exe,
        /// and pass arguments that specify your application name.
        /// </summary>
        /// <param name="loginSettings"></param>
        public void SetLoginItemSettings(LoginSettings loginSettings)
        {
            BridgeConnector.Socket.Emit("appSetLoginItemSettings", JObject.FromObject(loginSettings, _jsonSerializer));
        }

        /// <summary>
        /// This API will return true if the use of assistive technologies, 
        /// such as screen readers, has been detected. 
        /// See https://www.chromium.org/developers/design-documents/accessibility for more details.
        /// </summary>
        /// <returns>true if Chrome’s accessibility support is enabled, false otherwise.</returns>
        public async Task<bool> IsAccessibilitySupportEnabledAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appIsAccessibilitySupportEnabledCompleted", (isAccessibilitySupportEnabled) =>
                {
                    BridgeConnector.Socket.Off("appIsAccessibilitySupportEnabledCompleted");
                    taskCompletionSource.SetResult((bool)isAccessibilitySupportEnabled);
                });

                BridgeConnector.Socket.Emit("appIsAccessibilitySupportEnabled");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Set the about panel options. This will override the values defined in the app's
        /// .plist file. See the Apple docs for more details.
        /// </summary>
        /// <param name="options"></param>
        public void SetAboutPanelOptions(AboutPanelOptions options)
        {
            BridgeConnector.Socket.Emit("appSetAboutPanelOptions", JObject.FromObject(options, _jsonSerializer));
        }

        /// <summary>
        /// When critical is passed, the dock icon will bounce until either the application
        /// becomes active or the request is canceled.When informational is passed, the
        /// dock icon will bounce for one second.However, the request remains active until
        /// either the application becomes active or the request is canceled.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> DockBounceAsync(DockBounceType type, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<int>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appDockBounceCompleted", (id) =>
                {
                    BridgeConnector.Socket.Off("appDockBounceCompleted");
                    taskCompletionSource.SetResult((int)id);
                });

                BridgeConnector.Socket.Emit("appDockBounce", type.ToString());

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Cancel the bounce of id.
        /// </summary>
        /// <param name="id"></param>
        public void DockCancelBounce(int id)
        {
            BridgeConnector.Socket.Emit("appDockCancelBounce", id);
        }

        /// <summary>
        /// Bounces the Downloads stack if the filePath is inside the Downloads folder.
        /// </summary>
        /// <param name="filePath"></param>
        public void DockDownloadFinished(string filePath)
        {
            BridgeConnector.Socket.Emit("appDockDownloadFinished", filePath);
        }

        /// <summary>
        /// Sets the string to be displayed in the dock’s badging area.
        /// </summary>
        /// <param name="text"></param>
        public void DockSetBadge(string text)
        {
            BridgeConnector.Socket.Emit("appDockSetBadge", text);
        }

        /// <summary>
        /// Gets the string to be displayed in the dock’s badging area.
        /// </summary>
        /// <returns></returns>
        public async Task<string> DockGetBadgeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<string>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appDockGetBadgeCompleted", (text) =>
                {
                    BridgeConnector.Socket.Off("appDockGetBadgeCompleted");
                    taskCompletionSource.SetResult((string)text);
                });

                BridgeConnector.Socket.Emit("appDockGetBadge");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Hides the dock icon.
        /// </summary>
        public void DockHide()
        {
            BridgeConnector.Socket.Emit("appDockHide");
        }

        /// <summary>
        /// Shows the dock icon.
        /// </summary>
        public void DockShow()
        {
            BridgeConnector.Socket.Emit("appDockShow");
        }

        /// <summary>
        /// Whether the dock icon is visible. The app.dock.show() call is asynchronous
        /// so this method might not return true immediately after that call.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DockIsVisibleAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var taskCompletionSource = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => taskCompletionSource.TrySetCanceled()))
            {
                BridgeConnector.Socket.On("appDockIsVisibleCompleted", (isVisible) =>
                {
                    BridgeConnector.Socket.Off("appDockIsVisibleCompleted");
                    taskCompletionSource.SetResult((bool)isVisible);
                });

                BridgeConnector.Socket.Emit("appDockIsVisible");

                return await taskCompletionSource.Task
                    .ConfigureAwait(false);
            }
        }

        // TODO: Menu lösung für macOS muss gemacht werden und imeplementiert
        /// <summary>
        /// Sets the application's dock menu.
        /// </summary>
        public void DockSetMenu()
        {
            BridgeConnector.Socket.Emit("appDockSetMenu");
        }

        /// <summary>
        /// Sets the image associated with this dock icon.
        /// </summary>
        /// <param name="image"></param>
        public void DockSetIcon(string image)
        {
            BridgeConnector.Socket.Emit("appDockSetIcon", image);
        }

        internal void PreventQuit()
        {
            _preventQuit = true;
        }

        private bool _preventQuit = false;
    }
}
