#pragma warning disable CS1591

using System;
using System.Xml.Serialization;
using MediaBrowser.Model.Extensions;

namespace MediaBrowser.Model.Dlna
{
    public class ContainerProfile
    {
        [XmlAttribute("type")]
        public DlnaProfileType Type { get; set; }
        public ProfileCondition[] Conditions { get; set; }

        [XmlAttribute("container")]
        public string Container { get; set; }

        public ContainerProfile()
        {
            Conditions = Array.Empty<ProfileCondition>();
        }

        public string[] GetContainers()
        {
            return SplitValue(Container);
        }

        public static string[] SplitValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Array.Empty<string>();
            }

            return value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool ContainsContainer(string container)
        {
            var containers = GetContainers();

            return ContainsContainer(containers, container);
        }

        public static bool ContainsContainer(string profileContainers, string inputContainer)
        {
            var isNegativeList = false;
            if (profileContainers != null && profileContainers.StartsWith("-"))
            {
                isNegativeList = true;
                profileContainers = profileContainers.Substring(1);
            }

            return ContainsContainer(SplitValue(profileContainers), isNegativeList, inputContainer);
        }

        public static bool ContainsContainer(string[] profileContainers, string inputContainer)
        {
            return ContainsContainer(profileContainers, false, inputContainer);
        }

        public static bool ContainsContainer(string[] profileContainers, bool isNegativeList, string inputContainer)
        {
            if (profileContainers.Length == 0)
            {
                return true;
            }

            if (isNegativeList)
            {
                var allInputContainers = SplitValue(inputContainer);

                foreach (var container in allInputContainers)
                {
                    if (ListHelper.ContainsIgnoreCase(profileContainers, container))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                var allInputContainers = SplitValue(inputContainer);

                foreach (var container in allInputContainers)
                {
                    if (ListHelper.ContainsIgnoreCase(profileContainers, container))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
