using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace PoECommerce.Client.Components.Common
{
    public class PoECommerceComponentBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; } = "id_" + Guid.NewGuid();

        protected Dictionary<string, bool> States = new Dictionary<string, bool>();
        
        public string GetStateClass(string className)
        {
            StringBuilder classBuilder = new StringBuilder();

            classBuilder.Append(className);

            foreach (string state in States.Where(s => s.Value).Select(s => s.Key))
            {
                classBuilder.Append(" ").Append(className).Append("--").Append(state);
            }

            return classBuilder.ToString();
        }
    }
}