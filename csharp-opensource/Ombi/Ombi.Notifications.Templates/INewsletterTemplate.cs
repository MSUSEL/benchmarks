﻿namespace Ombi.Notifications.Templates
{
    public interface INewsletterTemplate
    {
        string LoadTemplate(string subject, string intro, string tableHtml, string logo);
    }
}