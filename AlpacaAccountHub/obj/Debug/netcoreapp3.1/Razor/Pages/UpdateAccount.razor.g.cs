#pragma checksum "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "028d1e2e50df5e5596351522a46a6992bdce96f4"
// <auto-generated/>
#pragma warning disable 1591
namespace AlpacaAccountHub.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using AlpacaAccountHub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using AlpacaAccountHub.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
using AlpacaAccountHub.AlpacaRequests;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
using AlpacaAccountHub.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
using AlpacaAccountHub.Data.ApiKeys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
using AlpacaAccountHub.UpdateAccount;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
using AlpacaAccountHub.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/update-account")]
    public partial class UpdateAccount : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 14 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
 if (accountInfo == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 17 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
}
else
{



#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "orderContainer");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "buySellContainer");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.AddMarkupContent(9, "<h2 style=\"align-content: center\">Update your API keys</h2>\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "symbolFlex");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.AddMarkupContent(13, "<label for=\"apiKey\">API_KEY:</label>\r\n                ");
            __builder.OpenElement(14, "input");
            __builder.AddAttribute(15, "type", "text");
            __builder.AddAttribute(16, "id", "apiKey");
            __builder.AddAttribute(17, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 27 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
                                                            keys.API_KEY

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => keys.API_KEY = __value, keys.API_KEY));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n                ");
            __builder.AddMarkupContent(20, "<label for=\"apiSecret\">API_SECRET:</label>\r\n                ");
            __builder.OpenElement(21, "input");
            __builder.AddAttribute(22, "type", "text");
            __builder.AddAttribute(23, "id", "apiSecret");
            __builder.AddAttribute(24, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 29 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
                                                               keys.API_SECRET

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => keys.API_SECRET = __value, keys.API_SECRET));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "type", "submit");
            __builder.AddAttribute(29, "id", "searchSymbolButton");
            __builder.AddAttribute(30, "form", "searchTicker");
            __builder.AddAttribute(31, "value", "Update Keys");
            __builder.AddAttribute(32, "name", "searchSymbol");
            __builder.AddAttribute(33, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 30 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
                                                                                                                                    UpdateKeys

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(34, "Update Keys");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n        ");
            __builder.OpenElement(38, "div");
            __builder.AddMarkupContent(39, "\r\n");
#nullable restore
#line 34 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
             foreach (var key in storedKeys)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(40, "                ");
            __builder.OpenElement(41, "p");
            __builder.AddContent(42, "Key: ");
            __builder.AddContent(43, 
#nullable restore
#line 36 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
                         key.API_KEY

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                ");
            __builder.OpenElement(45, "p");
            __builder.AddContent(46, "Secret: ");
            __builder.AddContent(47, 
#nullable restore
#line 37 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
                            key.API_SECRET

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n");
#nullable restore
#line 38 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(49, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n");
#nullable restore
#line 41 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "C:\Day Trading\alpaca\AlpacaAccountHub\feature-PlaceOrder\TradingAccountHub\AlpacaAccountHub\Pages\UpdateAccount.razor"
 

    private AlpacaAccountData accountInfo;
    private AlpacaApiKey keys = new AlpacaApiKey();
    private string[] apiKeys { get; set; } = new string[2];
    private List<AlpacaApiKey> storedKeys = new List<AlpacaApiKey>();

    protected override async Task OnInitializedAsync()
    {
        accountInfo = await AccountInfo.AccountInfo();
        storedKeys = DisplayKey.DisplayKey();

    }

    public void UpdateKeys()
    {
        apiKeys[0] = keys.API_KEY;
        apiKeys[1] = keys.API_SECRET;
        AddKey.AddKey(apiKeys);
    }

    async Task LogUsername()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UpdateKeys AddKey { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private UpdateKeys DisplayKey { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AlpacaAccountInfo AccountInfo { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
