# Automative Repair Shop
Bu projede bir otomotiv tamirhanesinin günlük işlemlerinin bir kısmının .Net Core Web uygulaması ile süreç olarak dijitalleştirilmesi hedeflenmektedir.
## Database Configuration
  - Clone from Github and open with Visual Studio
  - Open Package Manager Console in Visual Studio
  - Type the following command: update-database 
  - ConnectionString is located in appsettings.json in MovieStore.Web Layer
  
  ## Proje Mimarisi
N-Tier mimari kullanıldı, projede 4 katman bulunmaktadır.
- AutomativeRepairShop.Business Katmanı (Business Logic)
Veri tabanından verileri alarak gerekli business işlemlerini yapıp sunum katmanına gönderir veya sunum katmanından gelen istekleri için gerekli business işlemlerini yapıp veri tabanına gönderir. Verileri AutomativeRepairShop.Core katmanı vasıtasıyla alır veya gönderir, bu yüzden bu katmana bağımlılığı vardır.
- AutomativeRepairShop.Core Katmanı(Infrastructure) 
Projenin altyapı katmanıdır. Dependency injection için gerekli interface yapıları bu katmanda tanımlanır ve tanımlanan Dto nesneleri ile katmanlar arası veri aktarımını sağlar. 
- AutomativeRepairShop.Data Katmanı (Data Access)
Veritabanı işlemlerinden sorumlu katmandır, bu nedenle veritabanı ile ilgili classlar bu katmanda tanımlanır. Veri tabanı işlemlerinde Entity Framework Repository Pattern kullanılmıştır. Verileri AutomativeRepairShop.Core katmanı vasıtasıyla alır veya gönderir, bu yüzden bu katmana bağımlılığı vardır.
- AutomativeRepairShop.Web Katmanı (Presentation)
Mvc patterninin bulunduğu kullanıcı arayüz katmanıdır. Kullanıcı arayüzden yapılan requestler göre AutomativeRepairShop.Business katmanına AutomativeRepairShop.Core katmanı vasıtasıyla veri gönderir veya alır.
### Data Flow
- Presentation (AutomativeRepairShop.Web) -> Business (AutomativeRepairShop.Business) -> Data Access (AutomativeRepairShop.Data) --> Database
- Presentation (AutomativeRepairShop.Web) <- Business (AutomativeRepairShop.Business) <- Data Access (AutomativeRepairShop.Data) <-- Database
## Database Design
Veritabanı oluşturulurken Entity Framework Code-First yaklaşımı kullanıldı. Repository Pattern olabildiğince Generic yapılmaya çalışıldı. Crud işlemleri UnitOfWork class üzerinden yapıldı.
- DbContext-> AutomativeRepairShop.Data.DataAccess
- Models(Entities) -> AutomativeRepairShop.Core.Models
- Mapping -> AutomativeRepairSho.Data.Mapping
- Repository-> AutomativeRepairShop.Data.Repositories
- IRepositoy-> AutomativeRepairShop.Core.Repositories
- UnitOfWork->AutomativeRepairShop.Data.UnitOfWork
- IUnitOfWork->AutomativeRepairShop.Core.UnitOfWork
### Entities
- Customer (Müşteri)
- Vehicle (Araç) 
- Appointment (Randevu)
- WorkOrder (İş Emri)
### Entity Relationships
- Customer 1-n Vehicle
- Vehicle 1-n Appointment
- Appointment 1-n WorkOrder
## Controllers
### Customer Controller
It was created to insert, update, delete and list Customers.
- Customer/AddCustomer-> to create a new Customer
- Customer/UpdateCustomer-> to update a Customer
- Customer/DeleteCustomer-> to delete a Customer
- Customer/CustomerList-> to list all Customers from the database
### Vehicle Controller
It was created to insert, update, delete and list Vehicles.
- Vehicle/AddVehicle-> to create a new Vehicle
- Vehicle/UpdateVehicle-> to update a Vehicle
- Vehicle/DeleteVehicle-> to delete a Vehicle
- Vehicle/VehicleList-> to list all Vehicles from the database
### Appointment Controller
It was created to insert, update, delete and list Appointments.
- Appointment/AddAppointment-> to create a new Appointment
- Appointment/UpdateAppointment-> to update an Appointment
- Appointment/DeleteAppointment-> to delete an Appointment
- Appointment/AppointmentList-> to list all Appointments from the database
- Appointment/ApproveAppointment-> to approve an existing Appointment to create a new Work Order
### WorkOrder Controller
It was created to insert, update, delete and list WorkOrders.
- WorkOrder/AddWorkOrder-> to create a new WorkOrder
- WorkOrder/DeleteWorkOrder-> to delete a WorkOrder
- WorkOrder/WorkOrderList-> to list all WorkOrders from the database
