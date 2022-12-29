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
	- Verificar PInsert:
		- El select se usó automaticamente
		- En el controller tblEmpleadosController buscar Create()
			- En db.tblEmpleados.Add(tblEmpleados); ir a la definicion de db.tblEmpleados.Add (esto lleva a Modelo.edmx/ModeloEmpresa.Context.cs)
		- verificar que exista el metodo PInsert()
		- En ObjectResult se puede ver que llama a Pselect
	- Quitar Edit, Delete, Details de la vista:
		- ir a Views/tblEmpleados > Index.cshtml > comentar los @Html.ActionLink(); >> <!-- -->

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
- Agregar stored procedures:
	- Actualizar conexion desde ModeloEmpresa.edmx
	- Agregar > Funciones y procedimientos > Finalizar
	- ModeloEmpresa.edmx > Asignacion de almacenamiento almacenado
	- Funciones: Insertar mediante > buscar "PInsert" > Parametros > colocar los nombres de las variables
Otros:
- Firewall local: Permitir aplicacion:
	- Compartir archivos e imprsoras
	- Enrutamiento y acceso remoto
	- Escritorio remoto
- Colocar la conexion de BD de datos con usuario y contraseña evita que falle la conexion, esto se puede ver en el conextion string
	- <connectionStrings><add name="EmpresaEntities" connectionString="metadata=res://*/ModeloEmpresa.csdl|res://*/ModeloEmpresa.ssdl|res://*/ModeloEmpresa.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=192.168.0.20\SERVER\SQLEXPRESS,1433;initial catalog=Empresa;persist security info=True;user id=bduserX;password=admin1234;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>
	
	
	
Agregar Correos en la BD y en codigo
- Agregar Correos, not null, unique
- Actualizar los stored procedures
- Actualizar el modelo de vista desde ModeloEmpresa.edmx
- Actualizar almacenamientos almacenados > Insert > PInsert, agregar variable Correos
- Actualizar controlador Controllers/tblEmpleadosController
	- Agregar campo Correos en Create(): public ActionResult Create([Bind(Include = "ID,Nombres,Apellidos,Correos")]
- Actualizar vistas
	- Views/tblEmpleados/Index
		- Agregar columna Correos en "Table" en la vista: <th>  @Html.DisplayNameFor(model => model.Correos) </th>
		- Agregar en el foreach los correos: <td>     @Html.DisplayFor(modelItem => item.Correos)    </td>
	- Views/tblEmpleados/Create
		- Agregar información faltante entre <div class="form-group"> </div> para  model.Correos

Agregar funcionalidad enviar correos
Fuente: https://www.c-sharpcorner.com/UploadFile/sourabh_mishra1/sending-an-e-mail-using-Asp-Net-mvc/

- Nueva clase: Models/MailModel 

```
    public class MailModel
    {
        public string From { get;set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
```

- Nuevo Controlador: Controllers/SendMailController.cs > MVC5 en blanco
```
        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(MailModel _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("username", "password"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }
```

- Nueva vista: Views/SendMail - Vista MVC5 en blanco
```
@model RegistroEmpleados.Models.MailModel

@{
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Index</h2>
<fieldset>
    <legend>
        Send Email
    </legend>
    @using (Html.BeginForm())
    {
        @Html.ValidationSummary()
        <p>From: </p>
        <p>@Html.TextBoxFor(model => model.From)</p>
        <p>To: </p>
        <p>@Html.TextBoxFor(model => model.To)</p>
        <p>Subject: </p>
        <p>@Html.TextBoxFor(model => model.Subject)</p>
        <p>Body: </p>
        <p>@Html.TextAreaFor(model => model.Body)</p>
        <input type="submit" value="Send" />
    }
</fieldset>
```

