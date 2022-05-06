#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    using System;
    
    #line 2 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class EnqueuedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
  
    Layout = new LayoutPage(Queue.ToUpperInvariant());

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);

    var monitor = Storage.GetMonitoringApi();
    var pager = new Pager(from, perPage, monitor.EnqueuedCount(Queue));
    var enqueuedJobs = monitor.EnqueuedJobs(Queue, pager.FromRecord, pager.RecordsPerPage);


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");


            
            #line 24 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
   Write(Html.JobsSidebar());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        ");


            
            #line 27 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
   Write(Html.Breadcrumbs(Queue.ToUpperInvariant(), new Dictionary<string, string>
        {
            { "Queues", Url.LinkToQueues() }
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        <h1 class=\"page-header\">");


            
            #line 32 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                           Write(Queue.ToUpperInvariant());

            
            #line default
            #line hidden
WriteLiteral(" <small>");


            
            #line 32 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                            Write(Strings.EnqueuedJobsPage_Title);

            
            #line default
            #line hidden
WriteLiteral("</small></h1>\r\n\r\n");


            
            #line 34 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
         if (pager.TotalPageCount == 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-info\">\r\n                ");


            
            #line 37 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
           Write(Strings.EnqueuedJobsPage_NoJobs);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 39 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"js-jobs-list\">\r\n                <div class=\"btn-toolbar b" +
"tn-toolbar-top\">\r\n");


            
            #line 44 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                     if (!IsReadOnly)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <button class=\"js-jobs-list-command btn btn-sm btn-defaul" +
"t\"\r\n                                data-url=\"");


            
            #line 47 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                     Write(Url.To("/jobs/enqueued/delete"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                data-loading-text=\"");


            
            #line 48 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                              Write(Strings.Common_Deleting);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                data-confirm=\"");


            
            #line 49 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                         Write(Strings.Common_DeleteConfirm);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                disabled=\"disabled\">\r\n                        " +
"    <span class=\"glyphicon glyphicon-remove\"></span>\r\n                          " +
"  ");


            
            #line 52 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                       Write(Strings.Common_DeleteSelected);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </button>\r\n");


            
            #line 54 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    ");


            
            #line 55 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
               Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div class=\"table-responsive\">\r\n     " +
"               <table class=\"table\">\r\n                        <thead>\r\n         " +
"               <tr>\r\n");


            
            #line 62 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                             if (!IsReadOnly)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <th class=\"min-width\">\r\n                         " +
"           <input type=\"checkbox\" class=\"js-jobs-list-select-all\"/>\r\n           " +
"                     </th>\r\n");


            
            #line 67 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            <th class=\"min-width\">");


            
            #line 68 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                             Write(Strings.Common_Id);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th class=\"min-width\">");


            
            #line 69 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                             Write(Strings.Common_State);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th>");


            
            #line 70 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                           Write(Strings.Common_Job);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            <th class=\"align-right\">");


            
            #line 71 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                               Write(Strings.Common_Enqueued);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        </tr>\r\n                        </thead>\r\n         " +
"               <tbody>\r\n");


            
            #line 75 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                         foreach (var job in enqueuedJobs)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <tr class=\"js-jobs-list-row hover ");


            
            #line 77 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                          Write(job.Value == null || !job.Value.InEnqueuedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n");


            
            #line 78 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                 if (!IsReadOnly)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <td>\r\n");


            
            #line 81 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                         if (job.Value != null)
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <input type=\"checkbox\" class=\"js-jobs" +
"-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 83 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                                                                                 Write(job.Key);

            
            #line default
            #line hidden
WriteLiteral("\"/>\r\n");


            
            #line 84 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n");


            
            #line 86 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                <td class=\"min-width\">\r\n                         " +
"           ");


            
            #line 88 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                               Write(Html.JobIdLink(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 89 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                     if (job.Value != null && !job.Value.InEnqueuedState)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <span title=\"");


            
            #line 91 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                Write(Strings.Common_JobStateChanged_Text);

            
            #line default
            #line hidden
WriteLiteral("\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 92 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </td>\r\n");


            
            #line 94 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                 if (job.Value == null)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <td colspan=\"3\"><em>");


            
            #line 96 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                   Write(Strings.Common_JobExpired);

            
            #line default
            #line hidden
WriteLiteral("</em></td>\r\n");


            
            #line 97 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <td class=\"min-width\">\r\n                     " +
"                   ");


            
            #line 101 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                   Write(Html.StateLabel(job.Value.State));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n");



WriteLiteral("                                    <td class=\"word-break\">\r\n                    " +
"                    ");


            
            #line 104 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                   Write(Html.JobNameLink(job.Key, job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n");



WriteLiteral("                                    <td class=\"align-right\">\r\n");


            
            #line 107 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                         if (job.Value.EnqueuedAt.HasValue)
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 109 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                       Write(Html.RelativeTime(job.Value.EnqueuedAt.Value));

            
            #line default
            #line hidden
            
            #line 109 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                                                                          
                                        }
                                        else
                                        {

            
            #line default
            #line hidden
WriteLiteral("                                            <em>");


            
            #line 113 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                           Write(Strings.Common_NotAvailable);

            
            #line default
            #line hidden
WriteLiteral("</em>\r\n");


            
            #line 114 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n");


            
            #line 116 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tr>\r\n");


            
            #line 118 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        </tbody>\r\n                    </table>\r\n                <" +
"/div>\r\n\r\n                ");


            
            #line 123 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
           Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 125 "..\..\Dashboard\Pages\EnqueuedJobsPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
