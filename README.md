# Lab 09 - Software Testing

## Yêu cầu môi trường
- .NET SDK 8.0
- Visual Studio 2022
- Google Chrome

## Cấu trúc bài làm
- `src/BasicMath`: Ứng dụng console demo các phép tính (Bài 1 & 2)
- `tests/BasicMathTests`: Unit test kiểm thử BasicMath với file CSV (Bài 1 & 2)
- `src/BankAccountApp`: Lớp BankAccount mô phỏng nghiệp vụ tài khoản ngân hàng (Bài 3)
- `tests/BankAccountTests`: Unit test kiểm thử BankAccount với file CSV (Bài 3)
- `tests/LoginAutomation`: Kiểm thử tự động trang login với Selenium WebDriver (Bài 4)

## Hướng dẫn chạy

### 1. Chạy trên Visual Studio
- Mở file `SE_Lab9_524K0021.sln`.
- **Chạy demo console:** Nhấn **F5** (dự án `BasicMath` là Startup Project).
- **Chạy toàn bộ unit test:** Mở menu **Test** -> **Test Explorer** (`Ctrl + E, T`), nhấn nút **Run All** (`Ctrl + R, A`).
- **Chạy riêng Bài 4 (Selenium):** Trong bảng Test Explorer, chuột phải vào `LoginAutomation` -> chọn **Run**.

### 2. Chạy bằng dòng lệnh (CLI)
Mở terminal tại thư mục gốc của bài làm:

- Chạy app demo:
  ```bash
  dotnet run --project src/BasicMath
  ```

- Chạy toàn bộ 70 test case:
  ```bash
  dotnet test
  ```

- Chạy riêng từng bài test:
  ```bash
  dotnet test tests/BasicMathTests
  dotnet test tests/BankAccountTests
  dotnet test tests/LoginAutomation
  ```

### Lưu ý cho Bài 4 (Selenium):
Mặc định Selenium chạy ở chế độ headless (chạy ngầm). Nếu muốn hiển thị cửa sổ Chrome tự động gõ chữ và đăng nhập trên màn hình:
Mở file `tests/LoginAutomation/LoginTests.cs`, thêm dấu `//` trước dòng 43:
```csharp
// options.AddArgument("--headless=new");
```
