#pragma checksum "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "580b2489834d41ec8a4e1d26bd06a336294419f2"
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
#line 1 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using AlpacaAccountHub;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\_Imports.razor"
using AlpacaAccountHub.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
using AlpacaAccountHub.AlpacaRequests;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
using AlpacaAccountHub.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
using AlpacaAccountHub.Data.ApiKeys;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
using AlpacaAccountHub.UpdateAccount;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
using AlpacaAccountHub.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 style=\"align-content: center\">Welcome to your Account Hub!</h1>");
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\Day Trading\alpaca\AlpacaAccountHub\MASTER\AlpacaAccountHub\Pages\Index.razor"
 
    

    protected override async Task OnInitializedAsync()
    {
       
        Stream.Start();

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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private OpenConnection Stream { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AlpacaAccountInfo AccountInfo { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
