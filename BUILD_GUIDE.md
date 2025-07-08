# Hướng dẫn Build và Run Elsa Studio

Đây là hướng dẫn chi tiết để build và chạy project Elsa Studio trên macOS.

## Yêu cầu hệ thống

### 1. .NET SDK

- **.NET 8 SDK**: [Tải về tại đây](https://dotnet.microsoft.com/download/dotnet/8.0)
- **.NET 9 SDK**: [Tải về tại đây](https://dotnet.microsoft.com/download/dotnet/9.0)

Kiểm tra cài đặt:

```bash
dotnet --list-sdks
```

### 2. Node.js và npm

- **Node.js**: [Tải về tại đây](https://nodejs.org/) (bao gồm npm)

Kiểm tra cài đặt:

```bash
node --version
npm --version
```

## Các bước thực hiện

### Bước 1: Clone repository

```bash
git clone https://github.com/elsa-workflows/elsa-studio.git
cd elsa-studio
```

### Bước 2: Checkout branch chính thức

```bash
git checkout main
git pull origin main
```

### Bước 3: Build NPM assets (Quan trọng!)

#### 3.1. Build assets cho DomInterop

```bash
cd src/framework/Elsa.Studio.DomInterop/ClientLib
npm install
npm run build
cd ../../../../
```

#### 3.2. Build assets cho Workflows Designer

```bash
cd src/modules/Elsa.Studio.Workflows.Designer/ClientLib
npm install
npm run build
cd ../../../../
```

### Bước 4: Clean và Restore dependencies

```bash
# Clean solution
dotnet clean Elsa.Studio.sln

# Restore dependencies
dotnet restore Elsa.Studio.sln
```

### Bước 5: Build project

```bash
dotnet build Elsa.Studio.sln
```

**Lưu ý**: Build có thể có warnings nhưng không nên có errors. Nếu có errors, hãy kiểm tra lại các bước trước.

### Bước 6: Chạy ứng dụng

#### Tùy chọn 1: Blazor Server Host

```bash
dotnet run --project src/hosts/Elsa.Studio.Host.Server/Elsa.Studio.Host.Server.csproj --framework net9.0
```

#### Tùy chọn 2: Blazor WebAssembly Host

```bash
dotnet run --project src/hosts/Elsa.Studio.Host.Wasm/Elsa.Studio.Host.Wasm.csproj --framework net9.0
```

### Bước 7: Truy cập ứng dụng

Mở trình duyệt và truy cập:

- **Blazor Server**: `http://localhost:5010`
- **Blazor WASM**: `http://localhost:5000` (hoặc port được hiển thị trong console)

## Khắc phục sự cố

### Lỗi build NPM assets

- Đảm bảo đã cài đặt Node.js và npm
- Thử xóa folder `node_modules` và chạy lại `npm install`
- Kiểm tra quyền truy cập file

### Lỗi .NET build

- Kiểm tra đã cài đặt cả .NET 8 và .NET 9 SDK
- Chạy `dotnet clean` trước khi build lại
- Đảm bảo đang ở branch `main`

### Port đã được sử dụng

- Thay đổi port trong file `launchSettings.json`
- Hoặc kill process đang sử dụng port:

```bash
lsof -ti:5010 | xargs kill -9
```

### Lỗi Git merge conflicts

```bash
# Stash changes hiện tại
git stash

# Pull latest changes
git pull origin main

# Apply changes lại (nếu cần)
git stash pop
```

## Cấu trúc project quan trọng

```text
elsa-studio/
├── src/
│   ├── framework/
│   │   ├── Elsa.Studio.DomInterop/ClientLib/     # NPM assets
│   │   └── Elsa.Studio.Shared/
│   ├── modules/
│   │   ├── Elsa.Studio.Workflows.Designer/ClientLib/  # NPM assets
│   │   └── ...
│   └── hosts/
│       ├── Elsa.Studio.Host.Server/              # Blazor Server
│       └── Elsa.Studio.Host.Wasm/               # Blazor WASM
├── Elsa.Studio.sln
└── README.md
```

## Môi trường phát triển

### VS Code Extensions khuyến nghị

- C# Dev Kit
- Blazor WebAssembly Debugging
- npm Intellisense

### Visual Studio

Project hỗ trợ Visual Studio 2022 với workload:

- ASP.NET and web development
- .NET desktop development

## Ghi chú bổ sung

1. **NPM assets**: Bắt buộc phải build trước khi build .NET project
2. **Multiple frameworks**: Project support cả .NET 8 và .NET 9
3. **Localization**: Project hỗ trợ đa ngôn ngữ thông qua Weblate
4. **Architecture**: Modular design với MudBlazor UI framework

## Liên kết hữu ích

- [Elsa Workflows Documentation](https://elsa-workflows.github.io/elsa-core/)
- [MudBlazor Documentation](https://mudblazor.com/)
- [Blazor Documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/)
- [Project Repository](https://github.com/elsa-workflows/elsa-studio)

---

**Cập nhật lần cuối**: July 8, 2025
