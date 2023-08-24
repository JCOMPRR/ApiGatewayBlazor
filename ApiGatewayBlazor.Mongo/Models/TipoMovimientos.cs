using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiGatewayBlazor.Mongo.Models
{
    public class TipoMovimientos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; } //ID DEL MOVIMIENTO DE COMPRA O VENTA

        [BsonElement("productoID")] //ID DEL PRODUCTO QUE SE COMPRA O VENDE 
        public int IdProducto { get; set; }

        [BsonElement("descripcionProducto")] //DESCRIPCION DEL PRODUCTO QUE SE COMPRA O VENDE
        public string ProductoDescripcion { get; set; }

        [BsonElement("clienteID")] //ID DEL CLIENTE QUE REALIZA LA COMPRA O VENTA
        public int  IdCliente { get; set; }

        [BsonElement("tipoDeMovimiento")] 
        public bool Likes { get; set; } //SI ES TRUE ES UNA VENTA, SI ES FALSE ES UNA COMPRA
        public bool DisLikes { get; set; }
    }
}
