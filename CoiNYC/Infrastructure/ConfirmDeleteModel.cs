using System;
using System.Collections.Generic;
using System.Linq;

namespace CoiNYC.Infrastructure
{
    public class ConfirmDeleteModel
    {
        public int ShopId { get; set; }
        public string LanguageCode { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public string ActionName { get; set; }
        public string PostAction { get; set; }
        public ConfirmDeleteModel()
        {
            PostAction = "main.pageGrids[\"mainGrid\"].reloadGrid();";
        }
    }
}