#pragma checksum "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f33def53ae8de00299ea1ba90286319e4d7da69"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.AlpacaRequests;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.Data.AlpacaAccount;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.Data.ApiKeys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.Data.SymbolData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.PolygonRequests;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using AlpacaAccountHub.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using Microsoft.AspNetCore.DataProtection;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/order")]
    public partial class Order : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 266 "C:\Day Trading\alpaca\AlpacaAccountHub\fix-Registration\TradingAccountHub\AlpacaAccountHub\Pages\Order.razor"
 

    private PositionsData positions = new PositionsData();
    private PositionsData openPosition = new PositionsData();
    private AlpacaAccountData accountInfo;
    OrdersData order = new OrdersData();
    public static TickerDetails searchedSymbol = new TickerDetails();
    public static SubmittedOrder submittedOrder = new SubmittedOrder();
    public static SubmittedOrder canceledOrder = new SubmittedOrder();

    public string side { get; set; } = "";
    public string lookupSymbol { get; set; } = "";
    public string type { get; set; } = "limit";
    public string timeInForce { get; set; } = "gtc";

    protected override async Task OnInitializedAsync()
    {
        accountInfo = await AccountInfo.AccountInfo();

        System.Timers.Timer t = new System.Timers.Timer();
        t.Elapsed += async (s, e) =>
        {
            positions = await AllPositions.AllPositions();
            if (positions.numPositions != 0)
            {
                openPosition = await SinglePosition.SinglePosition(positions.symbol);
            }

            await InvokeAsync(StateHasChanged);
        };
        t.Interval = 3000;
        t.Start();


    }

    [JSInvokable]
    public async Task SearchSymbol()
    {
        lookupSymbol = order.symbol;
        Snapshot single = new Snapshot();
        // JSRuntime.InvokeVoidAsync("DisplayChart");
        searchedSymbol = await single.SingleTicker(order.symbol);

    }

    public void RadioSelection(ChangeEventArgs args)
    {
        side = args.Value.ToString();
    }

    public async Task ManualOrder()
    {
        SubmitOrder placeOrder = new SubmitOrder();
        submittedOrder = await placeOrder.PlaceOrder(order, type, timeInForce, side);
        Console.WriteLine(submittedOrder);


    }

    public async Task Cancel()
    {
        SubmitOrder cancel = new SubmitOrder();
        submittedOrder = await cancel.CancelOrder(submittedOrder.id);
        Console.WriteLine(canceledOrder);
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Positions SinglePosition { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Positions AllPositions { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Snapshot SingleTicker { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AlpacaAccountInfo AccountInfo { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SubmitOrder CancelOrder { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SubmitOrder PlaceOrder { get; set; }
    }
}
#pragma warning restore 1591
