﻿using ApiProject.WebApi.Context;
using ApiProject.WebApi.Dtos.ProductDtos;
using ApiProject.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("ürün ekleme başarılı");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            return Ok("Ürün başarıyla silindi");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("ürün güncelleme başarılı");
            }
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();

            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _context.Products.Include(x => x.Category).ToList();
            return Ok(value);
        }
    }
}
