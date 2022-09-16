using CoiNYC.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoiNYC.Core.Data
{
    

    public interface ITranslationDto
    {

    }

    public class LocalizedUniqueDto<T> : BaseUniqueDTO where T : class, ITranslationDto
    {
        public string LocalizedData { get; set; }
        private T _currentLanguage;
        public T CurrentLanguage
        {
            get
            {
                if (_currentLanguage == null)
                {
                    var langType = typeof(T);
                    var defaultData = ObjectMapper.Current.Map(this, this.GetType(), langType) as T;
                    if (!String.IsNullOrEmpty(LocalizedData))
                    {
                        var langData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(LocalizedData);
                        ObjectMapper.Current.Map(langData, defaultData, langType, langType);
                        LocalizedData = null;
                    }

                    _currentLanguage = defaultData;
                }

                return _currentLanguage;
            }
        }
    }
}
