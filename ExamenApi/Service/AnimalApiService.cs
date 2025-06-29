﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using ExamenApi.Core.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.Extensions.Logging;
using Azure;


namespace ExamenApi.Service;

    public class AnimalApiService
    {
    private readonly HttpClient _http;
    private readonly LoggerService _logger;

    public AnimalApiService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri("https://aes.shenlu.me/api/v1/");
        _logger = new LoggerService();
    }

    public async Task<List<Animal>> GetAllAsync()
    {
        var response = await _http.GetAsync("species");
        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<List<Animal>>(stream);
    }


    public async Task<Animal> SearchByNameAsync(string name)
    {
        var r = await _http.GetAsync($"species?common_name={name}");
        r.EnsureSuccessStatusCode();
        var json = await r.Content.ReadAsStreamAsync();
        var animals = JsonSerializer.Deserialize<List<Animal>>(json);
        return animals.FirstOrDefault();
    }

    public async Task<List<Animal>> GetByCountryCodeAsync(string code)
    {
        var r = await _http.GetAsync("species");
        r.EnsureSuccessStatusCode();
        var json = await r.Content.ReadAsStreamAsync();
        var animals = await JsonSerializer.DeserializeAsync<List<Animal>>(json);

        return animals
            .Where(a => string.Equals(a.CountryCode, code, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public async Task<List<Animal>> GetSortedAsync()
    {
        var list = await GetAllAsync();
        return list.OrderBy(a => a.CommonName).ToList();
    }
}

