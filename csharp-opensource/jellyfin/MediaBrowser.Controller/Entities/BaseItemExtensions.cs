using System.Linq;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.IO;

namespace MediaBrowser.Controller.Entities
{
    public static class BaseItemExtensions
    {
        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="imageType">Type of the image.</param>
        /// <returns>System.String.</returns>
        public static string GetImagePath(this BaseItem item, ImageType imageType)
        {
            return item.GetImagePath(imageType, 0);
        }

        public static bool HasImage(this BaseItem item, ImageType imageType)
        {
            return item.HasImage(imageType, 0);
        }

        /// <summary>
        /// Sets the image path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="imageType">Type of the image.</param>
        /// <param name="file">The file.</param>
        public static void SetImagePath(this BaseItem item, ImageType imageType, FileSystemMetadata file)
        {
            item.SetImagePath(imageType, 0, file);
        }

        /// <summary>
        /// Sets the image path.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="imageType">Type of the image.</param>
        /// <param name="file">The file.</param>
        public static void SetImagePath(this BaseItem item, ImageType imageType, string file)
        {
            if (file.StartsWith("http", System.StringComparison.OrdinalIgnoreCase))
            {
                item.SetImage(new ItemImageInfo
                {
                    Path = file,
                    Type = imageType
                }, 0);
            }
            else
            {
                item.SetImagePath(imageType, BaseItem.FileSystem.GetFileInfo(file));
            }
        }

        /// <summary>
        /// Copies all properties on object. Skips properties that do not exist.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="dest">The destination object.</param>
        public static void DeepCopy<T, TU>(this T source, TU dest)
        where T : BaseItem
        where TU : BaseItem
        {
            var destProps = typeof(TU).GetProperties().Where(x => x.CanWrite).ToList();

            foreach (var sourceProp in typeof(T).GetProperties())
            {
                // We should be able to write to the property
                // for both the source and destination type
                // This is only false when the derived type hides the base member
                // (which we shouldn't copy anyway)
                if (!sourceProp.CanRead || !sourceProp.CanWrite)
                {
                    continue;
                }

                var v = sourceProp.GetValue(source);
                if (v == null)
                {
                    continue;
                }

                var p = destProps.Find(x => x.Name == sourceProp.Name);
                if (p != null)
                {
                    p.SetValue(dest, v);
                }
            }
        }

        /// <summary>
        /// Copies all properties on newly created object. Skips properties that do not exist.
        /// </summary>
        /// <param name="source">The source object.</param>
        public static TU DeepCopy<T, TU>(this T source)
        where T : BaseItem
        where TU : BaseItem, new()
        {
            var dest = new TU();
            source.DeepCopy(dest);
            return dest;
        }
    }
}
