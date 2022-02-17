using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Orderly.Helpers
{
    /// <summary>
    /// Web view page
    /// </summary>
    /// <typeparam name="TModel">Model</typeparam>
    public abstract class OrderlyRazorPage<TModel> : RazorPage<TModel>
    {
        private Localizer _localizer;

        /// <summary>
        /// Get a localized resources
        /// </summary>
        public Localizer T
        {
            get
            {
                if (_localizer == null)
                {
                    _localizer = (format, args) =>
                    {
                        Assembly asm = Assembly.GetExecutingAssembly();
                        var valuex = asm.GetTypes().Where(type => type.FullName == "Orderly.Helpers.StringResources").FirstOrDefault();
                        object value;
                        try
                        {
                            value = valuex.GetField(format).GetValue(null);
                        }
                        catch(Exception ex)
                        {
                            value = format;
                        }
                        
                        var name = value == null ? string.Empty : value.ToString();
                        if (string.IsNullOrEmpty(name))
                        {
                            return new LocalizedString(format);
                        }
                        return new LocalizedString((args == null || args.Length == 0)
                            ? name
                            : string.Format(name, args));
                    };
                }
                return _localizer;
            }
        }

    }

    /// <summary>
    /// Web view page
    /// </summary>
    public abstract class OrderlyRazorPage : OrderlyRazorPage<dynamic>
    {
    }

    /// <summary>
    /// Localizer
    /// </summary>
    /// <param name="text">Text</param>
    /// <param name="args">Arguments for text</param>
    /// <returns>Localized string</returns>
    public delegate LocalizedString Localizer(string text, params object[] args);

    /// <summary>
    /// Localized string
    /// </summary>
    public class LocalizedString : HtmlString
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="localized">Localized value</param>
        public LocalizedString(string localized) : base(localized)
        {
            Text = localized;
        }

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; }
    }
}
