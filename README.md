# Scab — SVN CAD Asset Browser

Browse and preview CAD files (Autodesk Inventor, Fusion 360, STEP, STL) stored in SVN repositories, directly from VS Code.

## Architecture

```
VS Code Extension (TypeScript)
  ├── Tree view: browse SVN directories
  └── Webview: preview CAD thumbnails

ServerD (.NET 10 Windows daemon)
  ├── HTTP + gRPC (MagicOnion) API
  ├── SVN bridge (list / info / export via svn CLI)
  ├── Preview generation queue
  ├── Thumbnail cache (file-based, keyed by repo+path+revision)
  ├── Auth layer (JWT)
  └── Dispatches jobs to InteropWorker over localhost gRPC

InteropWorker (.NET 10 Windows process)
  ├── Inventor COM automation → PNG export
  ├── STEP / STL headless rendering
  └── Runs as MagicOnion gRPC server on port 5100
```

## Prerequisites

- .NET 10 SDK
- Node.js 20+
- SVN CLI (`svn`) on PATH
- Windows (for ServerD + InteropWorker)
- Autodesk Inventor (optional, for .ipt/.iam/.idw preview)

## Quick Start

```bash
git clone --recursive https://github.com/hnrobert/svn-cad-asset-browser.git
cd svn-cad-asset-browser

# Build backend
dotnet restore
dotnet build

# Run server
dotnet run --project src/Scab.ServerD

# Build VS Code extension
cd src/vscode-scab
npm install
npm run compile
# Press F5 in VS Code to launch extension dev host
```

## Project Structure

```
svn-cad-asset-browser/
├── Scab.slnx                       # .NET solution (new slnx format)
├── Directory.Build.props           # Shared MSBuild properties
├── src/
│   ├── Scab.Shared/                # Core shared types (AuthContext, MagicOnion extensions)
│   ├── Scab.ServerD.Shared/        # Shared DTOs + service interfaces (MessagePack + MagicOnion)
│   ├── Scab.ServerD/               # Server daemon (git submodule)
│   │   ├── Hosting/                # Bootstrap, AutoMapper, extensions
│   │   ├── Svn/                    # SVN browsing module
│   │   ├── Auth/                   # Authentication module
│   │   ├── Worker/                 # Job dispatch module
│   │   ├── Preview/                # Thumbnail generation module
│   │   └── Asset/                  # Asset metadata module
│   ├── Scab.InteropWorker/         # CAD render worker (git submodule)
│   │   ├── Hosting/                # Worker bootstrap
│   │   ├── Services/               # Inventor export, headless render
│   │   └── Interop/                # COM interop definitions
│   └── vscode-scab/                # VS Code extension (git submodule)
│       └── src/                    # TypeScript sources
```

## Modules

| Module | Purpose |
|--------|---------|
| **Svn** | SVN repository browsing via `svn` CLI wrapper |
| **Auth** | User authentication (JWT), SVN credential management |
| **Worker** | Dispatches render jobs to InteropWorker, manages process lifecycle |
| **Preview** | Thumbnail generation orchestration, file-based cache |
| **Asset** | Asset metadata, tagging, search |

## Configuration (`appsettings.json`)

```json
{
  "ConnectionStrings": {
    "Sqlite": "Data Source=scab.db"
  },
  "Scab": {
    "CachePath": "",
    "WorkerPort": 5100,
    "WorkerExePath": "Scab.InteropWorker.exe",
    "JwtSecret": "change-me-in-production"
  },
  "Kestrel": {
    "Endpoints": {
      "Http": { "Url": "http://0.0.0.0:5000" }
    }
  }
}
```

## Supported File Types

| Format | Extension | Preview Method |
|--------|-----------|----------------|
| Inventor Part | `.ipt` | COM automation / embedded thumbnail |
| Inventor Assembly | `.iam` | COM automation / embedded thumbnail |
| Inventor Drawing | `.idw` | COM automation |
| STEP | `.step`, `.stp` | Headless renderer |
| STL | `.stl` | Headless renderer |

## License

Apache License 2.0
