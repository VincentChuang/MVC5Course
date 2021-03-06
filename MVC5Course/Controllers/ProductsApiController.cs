﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC5Course.Models;

namespace MVC5Course.Controllers {
    public class ProductsApiController : ApiController {

        private FabricsEntities db = new FabricsEntities();

        public ProductsApiController() {
            //53 練習建立一個 ProductsApi 控制器 ( 要解決循環參考問題 )
            //db.Configuration.LazyLoadingEnabled = false;

            //55 設定 [JsonIgore] 在導覽屬性上，並重新啟用延遲載入特性 ( LazyLoadingEnabled = true )
        }

        // GET: api/ProductsApi
        //public IQueryable<Product> GetProduct() {
        //56 建立一個 ViewModel 自訂輸出不同欄位屬性的 JSON 格式
        public IQueryable<ProductApiViewModel> GetProduct() {
            //return db.Product;
            //56 建立一個 ViewModel 自訂輸出不同欄位屬性的 JSON 格式
            return from p in db.Product
                   select new ProductApiViewModel() {
                       id = p.ProductId,
                       name = p.ProductName
                   };
        }

        // GET: api/ProductsApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id) {
            Product product = db.Product.Find(id);
            if (product == null) {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/ProductsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId) {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                if (!ProductExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductsApi
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Product.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/ProductsApi/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id) {
            Product product = db.Product.Find(id);
            if (product == null) {
                return NotFound();
            }

            db.Product.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id) {
            //下述寫法建議改寫為 Any
            //return db.Product.Count(e => e.ProductId == id) > 0;
            return db.Product.Any(e => e.ProductId == id);
        }

    }
}