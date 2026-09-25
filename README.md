# Developer Portfolio Dashboard

An ASP.NET Core MVC app that logs in with GitHub OAuth and displays your GitHub profile and repositories on a dashboard.

## Features

- **GitHub OAuth login** — authenticate with your GitHub account, no local password/account system.
- **Dashboard** — shows the authenticated user's profile info and their repositories, pulled live from the GitHub API.
- **Session-based auth** — the GitHub access token is kept in server-side session state for the duration of the visit; logging out clears it.

## How it works

```
User clicks "Login with GitHub"
        │
        ▼
AuthController.Login ──► redirects to GitHub's OAuth authorize page
        │
        ▼
GitHub redirects back with a code
        │
        ▼
AuthController.Callback ──► exchanges the code for an access token
        │                    (stored in session)
        ▼
HomeController.Dashboard ──► uses the token via GitHubService
        │                     to fetch user + repos
        ▼
      Dashboard view
```

## Setup

This app requires a GitHub OAuth App to work, since it authenticates against GitHub's real OAuth flow.

1. Go to GitHub → **Settings → Developer settings → OAuth Apps → New OAuth App**
2. Set the **Authorization callback URL** to match your app's callback route (e.g. `https://localhost:{port}/Auth/Callback`)
3. Note the generated **Client ID** and **Client Secret**
4. Add them to your `appsettings.json` (or, better, [user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) for local development, so credentials never get committed):

```json
{
  "GitHub": {
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret",
    "RedirectUri": "https://localhost:{port}/Auth/Callback"
  }
}
```

⚠️ **Never commit real Client ID/Secret values to source control.** Use user secrets locally, and environment variables or a secrets manager in any deployed environment.

## Running it

Requires .NET 10 SDK (adjust if your project targets a different version).

```
cd Developer_Portfolio_Dashboard
dotnet run
```

Or open the `.sln` in Visual Studio and press Run. Then click "Login with GitHub" to start the OAuth flow.

## Tech stack

C# · ASP.NET Core MVC · GitHub OAuth · GitHub REST API

## Known limitations

- Access tokens are stored in session state only — closing the browser/session ends the login, there's no persistent "remember me."
- Requested OAuth scope (`read:user repo`) includes repo access; only public profile/repo data is currently displayed, so the scope could be narrowed to `read:user public_repo` if private repo access isn't needed.
