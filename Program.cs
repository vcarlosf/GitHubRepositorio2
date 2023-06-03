//definicion e inicializacion de los arreglos paralelos y el diccionario
using System.Collections;
String[] Departamento = { "Boaco", "Carazo", "Chinandega", "Chontales", "Costa Caribe Norte", "Costa Caribe Sur", "Estelí", "Granada", "Jinotega", "León", "Madriz", "Managua", "Masaya", "Matagalpa", "Nueva Segovia", "Río San Juan", "Rivas" };
int[] Poblacion = { 185013, 197139, 439906, 190863, 530586, 414543, 229866, 214317, 475630, 421050, 174744, 1546939, 391903, 593503, 271581, 135446, 182645 };
Dictionary<string, int> diccionario = Departamento
          .Zip(Poblacion, (k, v) => new { Clave = k, Valor = v })
          .ToDictionary(x => x.Clave, x => x.Valor);
//ordenando el diccionario de menor a mayor
var ordenado = diccionario.OrderBy(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
//fijando los nombres de los departamentos con menor y mayor poblacion
string minDepkey=ordenado.First().Key;
string maxDepkey=ordenado.Last().Key;
//reasignacion los arreglos paralelos
Departamento=ordenado.Keys.ToArray();
Poblacion=ordenado.Values.ToArray();
//mostrar los arreglos ordenados de menor a mayor
for (var i = 0; i < Poblacion.Length; i++)
    Console.WriteLine($"{Departamento[i],20} ==> {Poblacion[i],10:N0}");
//Suma de toda las poblaciones y nombre de menor a mayor
Console.WriteLine($"Población General:{Poblacion.Sum():N0}");
Console.WriteLine($"Departamento con mayor Población:{maxDepkey}");
Console.WriteLine($"Departamento con menor Población:{minDepkey}");
//mostrar el diccionario sin ordenar
Console.WriteLine($"datos desordenados");
foreach (var item in diccionario)
Console.WriteLine($"{item.Key,-20}==>{item.Value,10:N0}");
Console.WriteLine();
//ordenado cpn LINQ OrdeBy el diccionario
//sumar todas las poblaciones con SUM de LINQ
Console.WriteLine($"Población General:{diccionario.Values.Sum():NO}");
Console.WriteLine($"Departamento con mayor Población:{maxDepkey}");
Console.WriteLine($"Departamento con menor Población:{minDepkey}");
//poblacion promedio
Console.WriteLine($"poblacion promedio:{diccionario.Values.Average():N2}");
