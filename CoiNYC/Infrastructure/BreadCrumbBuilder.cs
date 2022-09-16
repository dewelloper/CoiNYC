using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Infrastructure
{
    public class Breadcrumb
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public string ActiveClass { get; set; }
    }

    public class BreadcrumbBuilder
    {
        private List<Breadcrumb> breadcrumbs = new List<Breadcrumb>();
        private string defaultActiveClass = "active";

        public BreadcrumbBuilder AddCurrentAction(string text, IUrlHelper url, ViewContext viewContext, bool active = false, string activeClass = null)
        {
            string currentAction = (string)viewContext.RouteData.Values["action"];
            string currentController = (string)viewContext.RouteData.Values["controller"];


            breadcrumbs.Add(new Breadcrumb { Name = text, IsActive = active, Url = url.Action(currentAction, currentController), ActiveClass = activeClass ?? defaultActiveClass });

            return this;
        }

        public BreadcrumbBuilder Add(string text, string url = null, bool active = false, string activeClass = null)
        {
            breadcrumbs.Add(new Breadcrumb { Name = text, IsActive = active, Url = url, ActiveClass = activeClass ?? defaultActiveClass });
            return this;
        }


        public BreadcrumbBuilder Add(Breadcrumb crumb)
        {
            breadcrumbs.Add(crumb);
            return this;
        }

        public List<Breadcrumb> Build()
        {
            return breadcrumbs;
        }
    }
}
