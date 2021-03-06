#pragma checksum "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "703868a18fac6ddceaf9838f2f92090986ea27a4"
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
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
using AlpacaAccountHub.Data.SymbolData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
using AlpacaAccountHub.PolygonRequests;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/top-twenty-gainers")]
    public partial class TopTwentyGainers : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Top 20 Gainers</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This component displays the top 20 gainers under $5 a share and a volume greater than 500,000.</p>\r\n\r\n");
#nullable restore
#line 14 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
 if (symbolsList == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.AddMarkupContent(3, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 17 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "    ");
            __builder.OpenElement(5, "table");
            __builder.AddAttribute(6, "id", "topGainers");
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.AddMarkupContent(8, @"<thead>
            <tr>
                
                <th>Symbol/Ticker</th>
                <th>Today's Percentage Change</th>
                <th>Today's Dollar Change</th>
                <th>Last Trade Price</th>
                <th>Last Minute Close</th>
            </tr>
        </thead>
        ");
            __builder.OpenElement(9, "tbody");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 32 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
             foreach (var symbol in symbolsList)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                 foreach (var stock in symbol.tickerDetails)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                    ");
            __builder.OpenElement(12, "tr");
            __builder.AddMarkupContent(13, "\r\n\r\n                        ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 38 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                             stock.ticker

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n                        ");
            __builder.OpenElement(17, "td");
            __builder.AddAttribute(18, "class", "postiveGain");
            __builder.AddContent(19, 
#nullable restore
#line 39 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                                                 stock.todaysChangePerc

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(20, "%");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                        ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 40 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                             stock.todaysChange

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                        ");
            __builder.OpenElement(25, "td");
            __builder.AddContent(26, 
#nullable restore
#line 41 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                             stock.lastTradePrice

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                        ");
            __builder.OpenElement(28, "td");
            __builder.AddContent(29, 
#nullable restore
#line 42 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                             stock.previousDayClose

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n");
#nullable restore
#line 44 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
                 
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
#nullable restore
#line 48 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
    
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\TopTwentyGainers.razor"
       
    private List<Symbols> symbolsList { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        symbolsList = await RunTopTwenty.RunTopTwenty();
        
    }

   


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Snapshot RunTopTwenty { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Snapshot TopTwenty { get; set; }
    }
}
#pragma warning restore 1591
