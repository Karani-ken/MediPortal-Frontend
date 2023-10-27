using Blazored.LocalStorage;
using MediPortal_Client;
using MediPortal_Client.Services.Appointment;
using MediPortal_Client.Services.Authentication;
using MediPortal_Client.Services.AuthProvider;
using MediPortal_Client.Services.Feedback;
using MediPortal_Client.Services.Hospital;
using MediPortal_Client.Services.Payment;
using MediPortal_Client.Services.Prescription;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IAuthInterface, AuthService>();
builder.Services.AddScoped<IHospitalInterface, HospitalService>();
builder.Services.AddScoped<IAppointmentInterface, AppointmentService>();
builder.Services.AddScoped<IPrescriptionInterface, PrescriptionService>();
builder.Services.AddScoped<IPaymentInterface, PaymentService>();
builder.Services.AddScoped<IFeedbackInterface, FeedService>();

//configuring the auth provider
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

await builder.Build().RunAsync();
