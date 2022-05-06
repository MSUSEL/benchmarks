﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using ScreenToGif.Util;

namespace ScreenToGif.Model
{
    [DataContract]
    public class ProjectInfo
    {
        /// <summary>
        /// The relative path of initial destination of this project.
        /// </summary>
        [DataMember(Name = "Relative", Order = 0)]
        public string RelativePath { get; set; }

        /// <summary>
        /// The date of reation of this project.
        /// </summary>
        [DataMember(Order = 1)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// List of frames.
        /// </summary>
        [DataMember(Order = 2)]
        public List<FrameInfo> Frames { get; set; } = new List<FrameInfo>();

        /// <summary>
        /// True if this project was recently created and was not yet loaded by the editor.
        /// </summary>
        [DataMember(Order = 3)]
        public bool IsNew { get; set; }

        /// <summary>
        /// Where this project was created?
        /// </summary>
        [DataMember(Order = 4)]
        public ProjectByType CreatedBy { get; set; } = ProjectByType.Unknown;

        /// <summary>
        /// The width of the canvas.
        /// </summary>
        [DataMember(Order = 5)]
        public int Width { get; set; }

        /// <summary>
        /// The height of the canvas.
        /// </summary>
        [DataMember(Order = 6)]
        public int Height { get; set; }

        /// <summary>
        /// The base dpi of the project.
        /// </summary>
        [DataMember(Order = 7)]
        public double Dpi { get; set; } = 96;

        /// <summary>
        /// The base bit depth of the project.
        /// 32 is RGBA
        /// 24 is RGB
        /// </summary>
        [DataMember(Order = 8)]
        public double BitDepth { get; set; } = 32;


        /// <summary>
        /// The full path of project based on current settings.
        /// </summary>
        public string FullPath => Path.Combine(UserSettings.All.TemporaryFolderResolved, "ScreenToGif", "Recording", RelativePath);

        /// <summary>
        /// Full path to the serialized project file. 
        /// </summary>
        public string ProjectPath => Path.Combine(FullPath, "Project.json");

        /// <summary>
        /// The full path to the action stack files (undo, redo).
        /// </summary>
        public string ActionStackPath => Path.Combine(FullPath, "ActionStack");

        /// <summary>
        /// The full path to the undo folder.
        /// </summary>
        public string UndoStackPath => Path.Combine(ActionStackPath, "Undo");

        /// <summary>
        /// The full path to the redo folder.
        /// </summary>
        public string RedoStackPath => Path.Combine(ActionStackPath, "Redo");

        /// <summary>
        /// The full path to the blob file, used by the recorder to write all frames pixels as a byte array, separated by a delimiter.
        /// </summary>
        public string CachePath => Path.Combine(UserSettings.All.TemporaryFolderResolved, "ScreenToGif", "Recording", RelativePath, "Frames.cache");

        /// <summary>
        /// Check if there's any frame on this project.
        /// </summary>
        public bool Any => Frames != null && Frames.Any();

        /// <summary>
        /// The latest index of the current list of frames, or -1.
        /// </summary>
        public int LatestIndex => Frames?.Count - 1 ?? -1;
        

        #region Methods

        public ProjectInfo CreateProjectFolder(ProjectByType creator)
        {

            IsNew = true;
            RelativePath = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + Path.DirectorySeparatorChar;
            CreatedBy = creator;

            Directory.CreateDirectory(FullPath);

            #region Create ActionStack folders

            if (!Directory.Exists(ActionStackPath))
                Directory.CreateDirectory(ActionStackPath);

            if (!Directory.Exists(UndoStackPath))
                Directory.CreateDirectory(UndoStackPath);

            if (!Directory.Exists(RedoStackPath))
                Directory.CreateDirectory(RedoStackPath);

            #endregion

            CreateMutex();

            return this;
        }

        public void Persist()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var ser = new DataContractJsonSerializer(typeof(ProjectInfo));

                    ser.WriteObject(ms, this);

                    File.WriteAllText(ProjectPath, Encoding.UTF8.GetString(ms.ToArray()));
                }
            }
            catch (Exception ex)
            {
                LogWriter.Log(ex, "Persisting the current project info.");
            }
        }

        public void Clear()
        {
            Frames?.Clear();

            MutexList.Remove(RelativePath);
        }

        public string FilenameOf(int index)
        {
            return Any && LatestIndex >= index ? Path.Combine(FullPath, Frames[index].Name) : "";
        }

        /// <summary>
        /// Gets the index that is in range of the current list of frames.
        /// </summary>
        /// <param name="index">The index to compare.</param>
        /// <returns>A valid index.</returns>
        public int ValidIndex(int index)
        {
            if (index == -1)
                index = 0;

            return LatestIndex >= index ? index : LatestIndex;
        }

        public void CreateMutex()
        {
            //TODO: Validate the possibility of openning this project.
            //I need to make sure that i'll release the mutexes.

            MutexList.Add(RelativePath);
        }

        public void ReleaseMutex()
        {
            MutexList.Remove(RelativePath);
        }

        /// <summary>
        /// Copy all necessary files to a new encode folder.
        /// </summary>
        /// <param name="usePadding">True if the file names should have a left pad, to preserve the file ordering.</param>
        /// <param name="copyJson">True if the Project.json file should be copied too.</param>
        /// <returns>A list of frames with the new path.</returns>
        internal List<FrameInfo> CopyToExport(bool usePadding = false, bool copyJson = false)
        {
            #region Output folder

            var folder = Path.Combine(FullPath, "Encode " + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss-ff"));

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            #endregion

            var newList = new List<FrameInfo>();

            try
            {
                #region If it's being exported as project, maintain file naming

                if (copyJson)
                {
                    foreach (var info in Frames)
                    {
                        var filename = Path.Combine(folder, Path.GetFileName(info.Path));

                        //Copy the image to the folder.
                        File.Copy(info.Path, filename, true);

                        //Create the new object and add to the list.
                        newList.Add(new FrameInfo(filename, info.Delay));
                    }

                    File.Copy(ProjectPath, Path.Combine(folder, "Project.json"), true);

                    return newList;
                }

                #endregion

                //Detect pad size.
                var pad = usePadding ? (Frames.Count - 1).ToString().Length : 0;

                foreach (var info in Frames)
                {
                    //Changes the path of the image. Writes as an ordered list of files, replacing the old filenames.
                    var filename = Path.Combine(folder, newList.Count.ToString().PadLeft(pad, '0') + ".png");

                    //Copy the image to the folder.
                    File.Copy(info.Path, filename, true);

                    //Create the new object and add to the list.
                    newList.Add(new FrameInfo(filename, info.Delay));
                }
            }
            catch (Exception ex)
            {
                LogWriter.Log(ex, "It was impossible to copy the files to encode.");
                throw;
            }

            return newList;
        }

        #endregion
    }
}