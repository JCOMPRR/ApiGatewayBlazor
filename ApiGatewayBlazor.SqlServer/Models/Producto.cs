using System;
using System.Collections.Generic;

namespace ApiGatewayBlazor.SqlServer.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? Precio { get; set; }
}
