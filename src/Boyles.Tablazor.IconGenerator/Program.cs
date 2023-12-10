

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Boyles.Tablazor.IconGenerator;

await using var stream = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "libman.json");
var model = await JsonSerializer.DeserializeAsync<LibManModel>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

Console.ReadKey();