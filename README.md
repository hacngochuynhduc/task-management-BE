# 🚀 Task Management System (STEAMHOUSE)

 Dự án sử dụng **.NET 8** cho Backend, hệ quản trị cơ sở dữ liệu **PostgreSQL**.

---
Nếu xài visual tím thì open solution file chọn STEAMHOUSE.sln open lên
Nếu vô không thấy nhánh thư mục thì click vào View chọn Solution Explore

Đổi password postgree trong appsettings.json trên STEAMHOUSE.Dashboard   xong Ctrl S lại.
Vô Developer Powershell
cd .\src\STEAMHOUSE.Infrastruture\
dotnet tool install --global dotnet-ef
Chạy migration (để apply db trên postgre) : dotnet ef database update
cd ..
cd .\STEAMHOUSE.Dashboard\
xong dotnet build
dotnet run


Check swagger : click vao https://localhost:6001/swagger

Nếu xài Rider:
