using System;

namespace DesafioDirmod
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Continue = true;

            // Interfaz de usuario
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("***** ESCRITURA EN TELEFONOS MOVILES *******");
            Console.WriteLine("***** PROGRAMA DE CALCULO ******************");
            Console.WriteLine("***** SECUENCIA DE PULSACION DE TECLAS *****");
            
            while(Continue)
            {
                string InputMessage, OutputSequence;    // Strings para el mensaje ingresado y la secuencia calculada a mostrar
                string InputContinue;
                bool Repeat = true;

                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("> Ingrese el mensaje (solamente letras y espacios):");
                InputMessage = Console.ReadLine();
                OutputSequence = ProcessMessage(InputMessage.ToLower());
                
                if(OutputSequence != null)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("> La secuencia para el mensaje ingresado es:\n" + OutputSequence);
                    Console.WriteLine("--------------------------------------------");
                }
                else
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("> El mensaje ingresado contiene caracteres no validos");
                    Console.WriteLine("--------------------------------------------");
                }
                
                while(Repeat)
                {
                    Console.WriteLine("> Ingresar otro mensaje? (s: Si / n: No)");
                    InputContinue = Console.ReadLine();
                    InputContinue = InputContinue.ToLower();
                    if(InputContinue.Length == 1)
                    {
                        if(InputContinue == "n")
                        {
                            Continue = false;
                            Repeat = false;
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("***** PROGRAMA FINALIZADO ******************");
                            Console.WriteLine("--------------------------------------------");
                        }
                        else if(InputContinue == "s")
                        {
                            Repeat = false;
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("> Ingrese una respuesta valida");
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("> Ingrese una respuesta valida");
                    }
                }
                
            }
        }

        // Funcion para procesar el mensaje ingresado y devolver la secuencia total calculada
        public static string ProcessMessage(string InputMessage)
        {
            string OutputSequence = null;       // Secuencia total calculada
            int Count = 0;

            // Calculo de secuencias para cada caracter del mensaje ingresado
            while(Count < InputMessage.Length)
            {
                string NewSequence;     // Nueva secuencia caculada para cada caracter
                NewSequence = ProcessCharacter(InputMessage[Count]);
                
                if(NewSequence != null)
                {
                    // Agrega espacios para indicar la pausa entre secuencias de la misma tecla
                    if(OutputSequence!= null)
                    {
                        if(NewSequence[0] == OutputSequence[OutputSequence.Length-1])
                        {
                            OutputSequence+= " ";
                        }
                    }

                    OutputSequence+= NewSequence;
                    Count++;
                }
                else
                {
                    OutputSequence = null;
                    Count = InputMessage.Length;
                }
                
            }
            
            return OutputSequence;
        }

        // Funcion para procesar cada caracter y devolver su secuencia calculada
        public static string ProcessCharacter(char InputCharacter)
        {
            string Sequence = null;     // Secuencia para el caracter
            
            // Calculo de la secuencia para el caracter utilizando el codigo ASCII
            if(InputCharacter >= 97 && InputCharacter <= 122)
            {
                int Count = 0, StartCharacter = 97, KeyNumber = 2, Reps = 1;
                bool Continue = true;

                while(Continue)
                {
                    int RepsMax = 4;

                    if(InputCharacter == StartCharacter+Count)
                    {
                        Continue = false;
                        for(int i=0; i<Reps; i++)
                        {
                            Sequence += Convert.ToString(KeyNumber);
                        }
                    }
                    else
                    {
                        Count++;
                        Reps++;
                        
                        if(KeyNumber == 7 || KeyNumber == 9)
                        {
                            RepsMax = 5;
                        }
                        
                        if(Reps == RepsMax)
                        {
                            Reps = 1;
                            KeyNumber++;
                        }
                    }
                }
            }
            else if(InputCharacter == 32)
            {
                Sequence += "0";
            }
            
            return Sequence;

        }

    }
}
