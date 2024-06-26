﻿/*
 * Created by SharpDevelop.
 * User: danie
 * Date: 08/05/2024
 * Time: 0:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace supermercado
{
	class Program
	{
		public struct producto
		{
			public string nombre;
			public Double precio;
			public string cat;
			
			public string[] categorias;
		}
		
		static StreamWriter Escribir;
		
		public static void Main(string[] args)
		{
			Console.Title = "R&B Soul";
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			
			producto var_producto;
//			var_producto.categorias = {"Abarrotes", "Bebidas", "Carnes", "Embutidos", "Frutas", "Verduras"};
			var_producto.categorias = new string[6];
			var_producto.categorias[0] = "Abarrotes";
			var_producto.categorias[1] = "Bebidas";
			var_producto.categorias[2] = "Carnes";
			var_producto.categorias[3] = "Embutidos";
			var_producto.categorias[4] = "Frutas";
			var_producto.categorias[5] = "Verduras";
			
			Console.Write("\n\t* ---------------------- *");
			Console.Write("\n\t|       BIENVENIDO       |");
			Console.Write("\n\t* ---------------------- *");
			Console.Write("\n\t|      Supermercado      |");
			Console.Write("\n\t|        R&B Soul        |");
			Console.WriteLine("\n\t* ---------------------- *");
			Console.ReadKey();
			Console.Clear();
			
			producto[] array_producto = new producto[5];
			for (int i = 0; i < 5; i++) {
				Console.WriteLine("\n\tProducto N°{0}", i+1);
				try {
					Console.Write("\n\tIngrese el nombre del producto: ");
					array_producto[i].nombre = Console.ReadLine();
					Console.Write("\tIngrese el precio del producto (##,##) : $ ");
					array_producto[i].precio = Double.Parse(Console.ReadLine());
					for (int j = 0; j < 6; j++) {
						Console.Write("\n\t{0}. {1}", j+1, var_producto.categorias[j]);
					}
					Console.Write("\n\n\tSeleccione la categoria: ");
					int opcion_cat = int.Parse(Console.ReadLine());
					array_producto[i].cat = var_producto.categorias[opcion_cat - 1];
				} catch (Exception e) {
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.Write("\n\t");
					Console.WriteLine(e.Message);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ReadKey();
					// Aqui se resta al valor de i, para que el usuario vuelva a ingresar los datos del registro que fallo
					i = i-1;
				}
				Console.Clear();
			}
			
			do
			{
				Console.Clear();
				try {
					Console.Write("\n\t¿Qué producto quiere mostrar? (Ingrese 0 para no mostrar productos) : ");
					int n = int.Parse(Console.ReadLine());
					if ((n>0) && (n<6)) {
						Console.Clear();
						imprimir(n, array_producto[n-1].nombre, array_producto[n-1].precio, array_producto[n-1].cat);
					} else if(n==0) {
						Console.Clear();
					} else {
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Red;
						Console.Write("\n\tDebe ingresar un número entre 1 y 5");
						Console.ForegroundColor = ConsoleColor.White;
						Console.BackgroundColor = ConsoleColor.Black;
					}
				} catch (Exception e) {
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.Write("\n\t");
					Console.WriteLine(e.Message);
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
				}
			} while(salir());
			
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.Cyan;
			Console.Write("\n\tLos productos ingresados se han registrado en un archivo de texto");
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			for (int i = 0; i < 5; i++) {
				archivo(i+1, array_producto[i].nombre, array_producto[i].precio, array_producto[i].cat);
			}
			try {
				Console.Write("\n\tAbriendo archivo...");
				Process.Start("C:/GitHub/supermercado/ficheros/productos.txt");
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
			}
			Console.ReadKey(true);
			creditos();
		}
		
		static void imprimir(int n, string a, Double b, string c)
		{
			try {
				// N° de prod
				Console.Write("\n\tProducto ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.DarkGray;
				Console.Write("N°{0}", n);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				// Nombre
				Console.Write("\n\tNombre del producto: ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write(a);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				// Precio
				Console.Write("\n\tPrecio del producto: ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.Green;
				Console.Write("$ {0}", b);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				// Categoria
				Console.Write("\n\tCategoría del producto: ");
				Console.ForegroundColor = ConsoleColor.Black;
				Console.BackgroundColor = ConsoleColor.Blue;
				Console.Write(c);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
			}
		}
		
		static void archivo(int n, string a, Double b, string c)
		{
			try {
				if (a.Equals("") || b.Equals("") || c.Equals("")) {
					Console.Write("\n\tProducto N°{0} vacio, ENTER para continuar al sig producto", n);
					Console.ReadKey();
				} else{
					Escribir = new StreamWriter("C:/GitHub/supermercado/ficheros/productos.txt", true);
					Escribir.Write("\n\tNombre del producto: {0}", a);
					Escribir.Write("\n\tPrecio del producto: $ {0}", b);
					Escribir.Write("\n\tCategoría del producto: {0}", c);
					Escribir.Write("\n\t*-------------------------*-------------------------*");
					Escribir.Close();
				}
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
			}
		}
		
		static Boolean salir()
		{
			try {
				Console.Write("\n\t¿Desea mostrar otro producto? [Y/N]: ");
				char resp = Console.ReadKey().KeyChar;
				
				if (resp == 'Y' || resp == 'y') {
					return true;
				} else {
//					creditos();
					return false;
				}
			} catch (Exception e) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Red;
				Console.Write("\n\t");
				Console.WriteLine(e.Message);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				
				return false;
			}
		}
		
		static void creditos()
		{
			Console.Clear();
			Console.WriteLine("\n\tGracias por su preferencia.");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("\tDaniel Alejandro Hernández Figueroa");
			Console.WriteLine("\tig:\thttps://www.instagram.com/dnlhernandez_/");
			Console.WriteLine("\tgithub:\thttps://github.com/ryukomvp");
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine("\n-> Fin del programa.");
			Console.ReadKey();
		}
	}
}