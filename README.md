# web ASP.NET framework
 Aplicación web asp.net .net framework 
 
 
- WEB
- C#
- Net Framework 4.6.1
- MVC
- No HTTPS
- CRUD: create, read, update, delete
- SQL server 2019

- Complementos
	- Microsfot Entity Framework
	
	
Fuente: https://www.youtube.com/watch?v=0Gu56u71G18&ab_channel=Develoteca
 
MVC:
 
Debe haber un equivalente de las clases de Controlles en Views:
- Controllers/HomeController -> Views/Home
- Los metodos en Controllers/Home hacen referencia a los cshtml en Views/Home
- En Views/Shared estan los templates que se usa en el proyecto por defecto (_Layout.cshtml)
- Codigo embebido en el HTML se llama Razor

- Actualizar contenido en una parte de la vista cshtml con `@RenderBody()`
- Crer Vista:
	- Views/Home
	- New View
	- Usar pagina de diseño: Buscar y seleccionar Views/Shared/_Layout
- BD: Empresa
- Tablas:
	- tblEmpleados
		- ID int - PK - identity
		- Nombres: nvarchar(50)
		- Apellidos: nvarchar(50)
		
Conexion a BD - SQLServer2019:
- Proyetco > Agregar > Nuevo elemento >> Datos >>ADO.NET Entity Data Model>> 1-EF Deigner desde base de datos
	- Nueva conexion > Microsfot SQL Server 
		- Nombre: 192.168.0.20\SERVER\SQLEXPRESS,1433
		- Autenticacion: Aut SQL Server
		- User: bduserX
		- Password: admin1234
		- BD: Empresa
		- Si, incluir datos confidenciales
		- Guardar configuracion en Web.Config: EmpresaEntities
		- Selecionar Tablas > dbo



Para los datos de la BD:
- Controllers > Agregar nuevo controlador > MVC con Entity Framwork (esto genera el controlador y la vista)
- Model class: tblEmpleados
- Clase contexto de datos: Empresa
- Generar vistas y use a layout page
- Para hacer que se memuestre la seccion Empleados:
	- Views/Shared/_Layout
	- Agregar ActionLink:  Nombre cualquiera, Metodo inicial del controlador, Controlador
			- Metodo inicial: public ActionResult Index(){...}
			- Controlador: tblEmpleadosController
		- <li>@Html.ActionLink("Empleados", "Index", "tblEmpleados")</li>
	- Para actualizar la conexion se puede desde: ModeloEmpresa.edmx > Actualizar Modelo de base de datos

Otros:
- Firewall local: Permitir aplicacion:
	- Compartir archivos e imprsoras
	- Enrutamiento y acceso remoto
	- Escritorio remoto
- Colocar la conexion de BD de datos con usuario y contraseña evita que falle la conexion, esto se puede ver en el conextion string
	- <connectionStrings><add name="EmpresaEntities" connectionString="metadata=res://*/ModeloEmpresa.csdl|res://*/ModeloEmpresa.ssdl|res://*/ModeloEmpresa.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=192.168.0.20\SERVER\SQLEXPRESS,1433;initial catalog=Empresa;persist security info=True;user id=bduserX;password=admin1234;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>