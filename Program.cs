// See https://aka.ms/new-console-template for more information
using Adivinar;
using System.ComponentModel;
using System.Diagnostics.Metrics;

//presentacion de juego
Console.WriteLine("Juego de adivinar respuestas!");
Console.WriteLine();

//inicializacion de variables
List<Pregunta> ListadoPreguntas = new List<Pregunta>();
Jugador jugador = new Jugador();
var DiccionarioPuntajesJugadores = new Dictionary<string, int>();


//ejecucion de funciones
ListadoPreguntas = GenerarPreguntas();
CapturarJugador();  
RecorrerPreguntas();


//funciones
List<Pregunta>  GenerarPreguntas()
{
    ListadoPreguntas.Add(new Pregunta
    {
        IdPregunta = 1,
        PreguntaTexto = "Como se llama nuestro perro",
        ListadoRespuestas = new List<Respuesta> 
        {
            new Respuesta { IdRespuesta= 1, RespuestaTexto="1) Manchita", EsValida= false },
            new Respuesta {IdRespuesta= 2, RespuestaTexto="2) Cockie", EsValida= true}
        }
    });

    ListadoPreguntas.Add(new Pregunta
    {
        IdPregunta = 2,
        PreguntaTexto = "Donde vivo?",
        ListadoRespuestas = new List<Respuesta>
        {
            new Respuesta {IdRespuesta = 1, RespuestaTexto= "1) Mendoza", EsValida= false },
            new Respuesta { IdRespuesta = 2, RespuestaTexto = "2) Villa Allende", EsValida= true}
        }
     });

   return ListadoPreguntas;    
}


void RecorrerPreguntas()
{
    int IdRespuestaCorrecta= 0;
    int respuestaCapturada = 0;
    

    foreach (var item in ListadoPreguntas)
    {
        Console.WriteLine(item.PreguntaTexto);

        foreach (var resp in item.ListadoRespuestas)
        {
            Console.WriteLine(resp.RespuestaTexto);

            if (resp.EsValida)
            {
                IdRespuestaCorrecta = resp.IdRespuesta;
            }
        }
        Console.WriteLine();
        respuestaCapturada = CapturarRespuestas();
        Console.WriteLine();
        
        if (IdRespuestaCorrecta == respuestaCapturada)
        {
          jugador.JugadorPuntaje++;
            respuestaCapturada = 0;
            AgregarPuntajesDiccionario(jugador.JugadorNombre, jugador.JugadorPuntaje);

        }
    };

    Console.WriteLine($"{jugador.JugadorNombre} tiene {jugador.JugadorPuntaje} puntos");

    JugarNuevamente();
}

int CapturarRespuestas()
{
    Console.WriteLine("Digite la respuesta correcta");
    
    string captura = Console.ReadLine();

    if (captura.Equals("1") || captura.Equals("2"))
    {
        return int.Parse(captura);

    } else 
    {
        Console.WriteLine("Vuelva a ingresar, opcion incorrecta");
        CapturarRespuestas();
    }

    return int.Parse(captura);    
}

void CapturarJugador()
{
    Console.WriteLine(  );
    Console.WriteLine("Escriba su nombre");

    Jugador jugadorCapturado = new Jugador();

    jugadorCapturado.JugadorNombre = Console.ReadLine();    

    buscarDiccionario(jugadorCapturado.JugadorNombre, jugadorCapturado.JugadorPuntaje); 

    if (jugador.JugadorNombre ==  jugadorCapturado.JugadorNombre )
    {
        buscarDiccionario(jugador.JugadorNombre, jugador.JugadorPuntaje);

        Console.WriteLine($"Hola de nuevo {jugador.JugadorNombre}, tenias {jugador.JugadorPuntaje} puntos");

        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Hola por primera vez {jugadorCapturado.JugadorNombre}");

        jugador.JugadorNombre = jugadorCapturado.JugadorNombre;        
        jugador.JugadorPuntaje = 0;

        Console.WriteLine();
    }
}

void JugarNuevamente()
{
    Console.WriteLine(  );
    Console.WriteLine("Quiere jugar de nuevo, 'si', otras teclas para cancelar" );
    string respuesta = Console.ReadLine();
    
    if (respuesta == "si")
    {
        Console.Clear();

        CapturarJugador();
        RecorrerPreguntas();     
    }
}

void AgregarPuntajesDiccionario(string p_nombreJugador, int p_puntajeJugador)
{

    if (DiccionarioPuntajesJugadores.ContainsKey(p_nombreJugador))
    {
        DiccionarioPuntajesJugadores.Remove(p_nombreJugador);
    }

    if (!DiccionarioPuntajesJugadores.ContainsKey(p_nombreJugador))
    {
        DiccionarioPuntajesJugadores.Add(p_nombreJugador, p_puntajeJugador);
    }

    mostrarDiccionario();   
}

void mostrarDiccionario()
{
    Console.WriteLine(  );
    Console.WriteLine("Puntajes de jugadores");

    foreach (var item in DiccionarioPuntajesJugadores)
    {
        Console.WriteLine($"Jugador: {item.Key} - Puntaje: {item.Value}");
    }
}

void buscarDiccionario(string p_nombreJugador, int p_puntajeJugador)
{
    if (DiccionarioPuntajesJugadores.Count == 0)
    {

    }
    else
    {
        foreach (var item in DiccionarioPuntajesJugadores)
        {
            if (item.Key.Equals(p_nombreJugador))
            {
                jugador.JugadorPuntaje = item.Value;
                jugador.JugadorNombre = item.Key;
            }
        }
    }
}


