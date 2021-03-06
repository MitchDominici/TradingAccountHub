#pragma checksum "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10184ebd4d29734813f1469f3e58cef4e0d7ab0a"
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
#line 1 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using AlpacaAccountHub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\_Imports.razor"
using AlpacaAccountHub.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
using AlpacaAccountHub.AlpacaRequests;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
using AlpacaAccountHub.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
using AlpacaAccountHub.Data.ApiKeys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
using AlpacaAccountHub.UpdateAccount;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
using AlpacaAccountHub.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/account-information")]
    public partial class AccountInformation : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 14 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
 if (accountInfo == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 17 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
}
else
{




#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "AccountHub");
            __builder.AddAttribute(5, "id", "AccountHub");
            __builder.AddMarkupContent(6, "\r\n\r\n        ");
            __builder.OpenElement(7, "table");
            __builder.AddAttribute(8, "class", "table-fill");
            __builder.AddMarkupContent(9, "\r\n            <colgroup span=\"2\"></colgroup>\r\n            ");
            __builder.AddMarkupContent(10, "<thead>\r\n                <tr>\r\n                    <th style=\"align-content: center\" colspan=\"2\">Alpaca Account Details</th>\r\n                </tr>\r\n            </thead>\r\n            ");
            __builder.OpenElement(11, "tbody");
            __builder.AddAttribute(12, "class", "table-hover");
            __builder.AddMarkupContent(13, "\r\n                ");
            __builder.OpenElement(14, "tr");
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "td");
            __builder.AddAttribute(17, "class", "text-left");
            __builder.AddAttribute(18, "colspan", "2");
            __builder.AddContent(19, 
#nullable restore
#line 34 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
                                                       accountInfo.today

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                ");
            __builder.OpenElement(22, "tr");
            __builder.AddMarkupContent(23, "\r\n                    ");
            __builder.AddMarkupContent(24, "<td class=\"text-left\">Number Of Day Trades:</td>\r\n                    ");
            __builder.OpenElement(25, "td");
            __builder.AddAttribute(26, "class", "text-left");
            __builder.AddContent(27, 
#nullable restore
#line 38 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
                                           accountInfo.numberOfDayTrades

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "tr");
            __builder.AddMarkupContent(31, "\r\n                    ");
            __builder.AddMarkupContent(32, "<td class=\"text-left\">Day Trade Buying Power:</td>\r\n                    ");
            __builder.OpenElement(33, "td");
            __builder.AddAttribute(34, "class", "text-left");
            __builder.AddContent(35, 
#nullable restore
#line 42 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
                                           accountInfo.dayTradingPower

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                ");
            __builder.OpenElement(38, "tr");
            __builder.AddMarkupContent(39, "\r\n                    ");
            __builder.AddMarkupContent(40, "<td class=\"text-left\">Equity:</td>\r\n                    ");
            __builder.OpenElement(41, "td");
            __builder.AddAttribute(42, "class", "text-left");
            __builder.AddContent(43, 
#nullable restore
#line 46 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
                                           accountInfo.equity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n");
#nullable restore
#line 52 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\AccountInformation.razor"
 

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
