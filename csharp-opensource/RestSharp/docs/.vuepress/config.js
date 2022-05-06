module.exports = {
    title: "RestSharp",
    description: "Simple .NET client for HTTP REST APIs",
    plugins: ["@vuepress/active-header-links"],
    themeConfig: {
        logo: "/restsharp.png",
        nav: [
            {text: "Get help", link: "/get-help/"},
            {text: "Gitter", link: "https://gitter.im/RestSharp/RestSharp"},
            {text: "NuGet", link: "https://nuget.org/packages/RestSharp"}
        ],
        sidebarDepth: 1,
        sidebar: [
            {
                title: "Getting Started",
                path: "/getting-started/",
                collapsable: false,
                // children: [
                //   '/getting-started/upgrade-v6'
                // ]
            },
            {
                title: "Using RestSharp",
                path: "/usage/",
                collapsable: false,
                children: [
                    "/usage/serialization",
                    "/usage/files",
                    "/usage/authenticators",
                    "/usage/parameters",
                    "/usage/exceptions"
                ]
            },
            {
                title: "Got stuck?",
                path: "/get-help/",
                collapsable: false,
                children: [
                    "/get-help/faq"
                ]
            },
            {
                title: "Reference",
                path: "/api/",
                collapsable: true,
                children: [
                    "/api/RestSharp.md"
                ]
            }
        ],
        searchPlaceholder: "Search...",
        lastUpdated: "Last Updated",
        repo: "restsharp/RestSharp",

        docsRepo: "restsharp/RestSharp",
        docsDir: "docs",
        docsBranch: "master",
        editLinks: true,
        editLinkText: "Help us by improving this page!"
    }
}
