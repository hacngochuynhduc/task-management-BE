<img width="1502" height="612" alt="image" src="https://github.com/user-attachments/assets/a0e1bb5f-a74c-4d98-90e2-0db170ed65f0" /># 🚀 Task Management System (STEAMHOUSE)

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

Nếu xài Rider: Vô termnial nhập <img width="1783" height="759" alt="image" src="https://github.com/user-attachments/assets/6d3e830b-17bf-43c3-97c2-e4a7eaddae30" />
``` bash
 cd .\src\STEAMHOUSE.Infrastruture\


Nhập lệnh để chạy migration:
``` bash
dotnet ef database update

<img width="1502" height="612" alt="image" src="https://github.com/user-attachments/assets/1e4eb0b2-485c-44f3-87c8-cb91a3d849f0" />

Xong cd về lại thư mục chính :
``` bash
cd ..

xong cd tới : cd .\STEAMHOUSE.Dashboard\
rồi dotnet run
<img width="1769" height="555" alt="image" src="https://github.com/user-attachments/assets/7e2dfd95-5886-4d6f-a734-e99e0c0feebc" />





Chạy Backend xong , thì qua đọc README của FE angular để chạy ( song song) phải chạy Backend rồi qua angular
