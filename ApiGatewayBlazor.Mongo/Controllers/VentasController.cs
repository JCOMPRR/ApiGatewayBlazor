using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using ApiGatewayBlazor.Mongo.Models;


namespace ApiGatewayBlazor.Mongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : Controller
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        private readonly IMongoCollection<TipoMovimientos> _collection;
        public VentasController()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("tipomovimientos");
            _collection = _database.GetCollection<TipoMovimientos>("movimientos");

        }

        //public VentasController()
        //{
        //    MongoClient client = new MongoClient("mongodb://localhost:27017");
        //    IMongoDatabase database = client.GetDatabase("tipo_movimientos");
        //    IMongoCollection<TipoMovimientos> collection = database.GetCollection<TipoMovimientos>("movimientos");
        //}


        [HttpGet]
        public async Task<IActionResult> ConsultarTipoMovimientos([FromBody] TipoMovimientos movimientos)
        {
            _ = new TipoMovimientos
            {
                IdProducto = movimientos.IdProducto,
                ProductoDescripcion = movimientos.ProductoDescripcion,
                IdCliente = movimientos.IdCliente
            };

            await _collection.InsertOneAsync(movimientos);

            return Ok("Venta generada exitosamente.");
        }

        [HttpPost]
        public async Task<IActionResult> GenerarTipoMovimientos([FromBody] TipoMovimientos movimientos)
        {
            if (movimientos == null)
                return BadRequest();
            if (movimientos.ProductoDescripcion == string.Empty)
            {
                ModelState.AddModelError("ProductoDescripcion", "La venta no ha sido encontrada");
            }
            await _collection.InsertOneAsync(movimientos);
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> GenerarLike([FromBody] TipoMovimientos like)
        //{
        //    _ = new TipoMovimientos
        //    {
        //        Likes = true
        //    };

        //    await _collection.InsertOneAsync(like);

        //    return Ok("Like Agregado.");
        //}

        //[HttpPost]
        //public async Task<IActionResult> GenerarDislike([FromBody] TipoMovimientos dislike)
        //{
        //    _ = new TipoMovimientos
        //    {
        //        DisLikes = true
        //    };

        //    await _collection.InsertOneAsync(dislike);

        //    return Ok("Dislike Agregado.");
        //}

    }
}
