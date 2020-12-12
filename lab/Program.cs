using lab.Builders;
using lab.Entities;
using lab.Presentation;
using lab.Repositories;
using System;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewController view = new ViewController("DefaultConnection");

            view.Run();
           
        }
    }
}
