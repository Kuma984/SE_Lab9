# SE Lab 09: Software Testing

Course: Software Engineering (FIT - TDTU)  
Instructor: Mr. Ky-Trung Pham (tg_phamthaikytrung@tdtu.edu.vn)  
Student: Trịnh Đức Long (524K0021)  
GitHub Repository: https://github.com/Kuma984/SE_Lab9.git  

---

## 1. Yêu cầu môi trường
- .NET SDK 8.0 trở lên
- Visual Studio 2022 (cài đặt workload .NET desktop / Web development)
- Google Chrome (dùng cho bài 4 Selenium)

---

## 2. Cấu trúc bài làm
Solution: `SE_Lab9_524K0021.sln`
- `src/BasicMath`: Console app chạy demo các phép tính (Bài 1 & 2)
- `tests/BasicMathTests`: Unit test xUnit kiểm thử lớp BasicMath và đọc file CSV (Bài 1 & 2 - 50 test case)
- `src/BankAccountApp`: Lớp BankAccount mô phỏng nghiệp vụ tài khoản ngân hàng (Bài 3)
- `tests/BankAccountTests`: Unit test kiểm thử lớp BankAccount với dữ liệu từ file CSV (Bài 3 - 16 test case)
- `tests/LoginAutomation`: Kiểm thử tự động trang đăng nhập bằng Selenium WebDriver (Bài 4 - 4 test case)

---

## 3. Hướng dẫn chạy

### Cách 1: Chạy trên Visual Studio (Khuyên dùng)
1. Mở file `SE_Lab9_524K0021.sln` bằng Visual Studio 2022.
2. **Chạy demo console (F5):**
   - Đảm bảo dự án `BasicMath` được chọn làm Startup Project.
   - Nhấn **F5** (hoặc nút Run màu xanh).
   - Màn hình console sẽ hiện kết quả tính toán demo của BasicMath, BankAccount và hướng dẫn chạy test, sau đó dừng lại chờ nhấn Enter (không bị tắt cửa sổ).
3. **Chạy toàn bộ 70 Unit Test:**
   - Trên menu trên cùng chọn **Test** -> **Test Explorer** (phím tắt `Ctrl + E, T`).
   - Nhấn nút **Run All Tests in View** (icon hình 2 tam giác xanh).
   - Toàn bộ 70 test case sẽ chạy và hiện tích xanh (Passed 100%).
4. **Chạy riêng Bài 4 (Selenium WebDriver):**
   - Trong bảng **Test Explorer**, mở rộng `LoginAutomation` -> `LoginTests`.
   - Chuột phải vào `LoginTests` chọn **Run**.

---

### Cách 2: Chạy nhanh bằng dòng lệnh (Terminal / PowerShell)
Mở terminal tại thư mục bài làm:

1. Chạy chương trình demo:
   ```powershell
   dotnet run --project src/BasicMath
   ```

2. Chạy toàn bộ 70 test case:
   ```powershell
   dotnet test
   ```

3. Chạy riêng từng bài kiểm thử:
   - Bài 1 & 2 (BasicMath):
     ```powershell
     dotnet test tests/BasicMathTests
     ```
   - Bài 3 (BankAccount):
     ```powershell
     dotnet test tests/BankAccountTests
     ```
   - Bài 4 (Selenium Login Automation):
     ```powershell
     dotnet test tests/LoginAutomation
     ```

> **Lưu ý riêng cho Bài 4:**  
> Mặc định Selenium chạy ở chế độ headless (chạy ngầm). Nếu muốn xem trực tiếp trình duyệt Chrome bật lên màn hình, tự động gõ username/password và tự click đăng nhập:  
> Mở file `tests/LoginAutomation/LoginTests.cs`, thêm dấu comment `//` ở dòng 43:  
> `// options.AddArgument("--headless=new");` rồi chạy lại test.
