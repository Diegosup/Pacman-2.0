# Manejo de errores

Parar saber manejar errores primero debemos conocer que python contiene excepciones integradas en las cuales se pueden consultar ingresando ell siguiente commando dentro de nuestro ambiente de desarrollo:
```ruby
print(dir(locals()['__builtins__']))
```
Dentro de las cuales en la siguiente tabla se muestran algunos errores junto con la causa por lo cual se generan

| Error |Causa del error|
|-------|-------------|
| AssertionError | Se genera cuando falla una instrucción `assert` |
| AttributeError | Se genera cuando falla la asignación de atributos o la referencia|
| EOFError | Se genera cuando la función `input()` alcanza la condición de fin de archivo|
| FloatingPointError | Se genera cuando falla una operación de punto flotante |
| GeneratorExit | Se genera cuando `close()` se llama al método de un generador |
| ImportError | Se genera cuando no se encuentra el módulo importado |
| IndexError | Se genera cuando el índice de una secuencia está fuera de rango |
| KeyError | Se genera cuando una clave no se encuentra en un diccionario |
| KeyboardInterrupt | Se genera cuando el usuario pulsa la tecla de interrupción (Ctrl+C o Delete) |
| MemoryError | Se genera cuando una operación se queda sin memoria |
| NameError | Se genera cuando una variable no se encuentra en el ámbito local o global |
| NotImplementedError | Generado por métodos abstractos. |
| OSError | Se genera cuando el funcionamiento del sistema provoca un error relacionado con el sistema |
| OverflowError | Se genera cuando el resultado de una operación aritmética es demasiado grande para ser representado |
| RuntimeError | Se genera cuando un error no pertenece a ninguna otra categoría |
| SyntaxError | Provocado por el analizador cuando se encuentra un error de sintaxis |
| IndentationError | Se levanta cuando hay una sangría incorrecta |
| TabError | Se genera cuando la sangría consiste en tabulaciones y espacios inconsistentes |
| SystemError | Se genera cuando el intérprete detecta un error interno |
| SystemExit | Generado por la función `sys.exit()` |
| TypeError | Se genera cuando se aplica una función u operación a un objeto de tipo incorrecto |
| ValueError | Se genera cuando una función obtiene un argumento del tipo correcto pero un valor incorrecto |
| ZeroDivisionError | Se genera cuando el segundo operando de la operación de división o módulo es cero |

Una vez contemplados las excepciones integradas en python, tenemos la posibilidad de personalizar el manejo de errores lo cuál es una buena práctica como programadores. Para empezar debemos saber que existen dos tipos de errores, el error de sintaxis y el error de excepción. La diferencia entre estos es que el error de sintaxis ocurre cuando al analizador detecta una declaración incorrecta, probemos con el siguiente ejemplo de código:
```ruby
print( 0 / 0 ))
```
Donde si lo compilamos, nos arroja lo siguiente:
```ruby
File "<stdin>", line 1
    print( 0 / 0 ))
                  ^
SyntaxError: invalid syntax
```
Lo cual indica que el analizador encontró que hay un paréntesis extra el cual está incompleto ya que no está encapsulando a un comando en específico. Por otro lado, el error de excepción ocurre cuando el código Python está sintácticamente correcto pero da como resultado un error, para compobarlo, probemos con el siguiente ejemplo:
```ruby
print( 0 / 0 )
```
Si lo compilamos, ahora nos da como resultado:
```ruby
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
ZeroDivisionError: integer division or modulo by zero
```
Lo que significa que el analizador no encontró errores de sintaxis, sin embargo, al compilar el código, se encontró la excepción de que la divisón no es válida ya que se está dividiendo sobre 0 lo cual matemáticamente no es válido.
# Excepción raise
Ya que ahora sabemos que existen dos tipos de errores, procederemos a manejar lo que son las excepciones comenzando con el commando `raise` que simplemente se encarga de lanzar una excepción de manera forzada al momento de cumplir cierta condición. Probemos con el siguiente ejemplo.
```ruby
x = 10
if x > 5:
    raise Exception('x should not exceed 5. The value of x was: {}'.format(x))
```
Por lo que al compilar, obtendremos lo siguiente:
```ruby
Traceback (most recent call last):
  File "<input>", line 4, in <module>
Exception: x should not exceed 5. The value of x was: 10
```
Lo cual explica que se lanzo la excepción programada debido a que se cumplió la condición de que el valor de x es mayor a 5, por el contrario, la excepción no se lanza y el código compila exitosamente.
# Excepción assert
El commando `assert` se encarga de asegurar que una determinada condición se cumpla donde si la condición es verdadera, entonces el programa continua ejecutándose, en cambio, si es falso, el programa lanza una excepción tipo assert. Probemos con el siguiente código:
```ruby
import sys
assert ('linux' in sys.platform), "This code runs on Linux only."
```
Esta excepción se encarga de verificar si nuestro sistema operativo es linux, por lo que si estamos en un sistema windows y lo compilamos, nos arroja lo siguiente:
```ruby
Traceback (most recent call last):
  File "<input>", line 2, in <module>
AssertionError: This code runs on Linux only.
```

# Excepción try y except
Los commandos `try` y `except` tienen un propósito similar al de if/else , donde try correrá el código que se encuentre dentro de su respectivo bloque mientras que si llegara el caso en el que se haya lanzado una excepción, el bloque except se activará y por lo tanto ejecutará todo código que se encuentre dentor de este bloque. Probemos con el ejemplo anterior colocando estos debajo de la función de la siguiente manera:
```ruby
try:
    linux_interaction()
except AssertionError as error:
    print(error)
    print('The linux_interaction() function was not executed')
```
Por lo que al ejecutarlo en un sistema windows nos arrojará lo siguiente:
```ruby
Function can only run on Linux systems.
The linux_interaction() function was not executed
```
Esto indica que el bloque try se ejecutó pero arrojo una excepción, por lo que el bloque except se activó y por lo tanto, mostró el error de assert de la función linux_iteraction() y después se imprimió que la función linux_iteraction() no se pudo ejecutar ya que dicha excepción se arrojo.

Por otra parte, que pasaría si usamos dos bloques except y un solo bloque try. Probemos con el siguiente ejemplo:
```ruby
def is_linux():
    return false;
def linux_interaction():
    assert is_linux(),"Function can only run on Linux systems"
    print('Doing something')
try:
    linux_interaction()
    with open('file.log') as file:
        read_data = file.read()
except FileNotFoundError as fnf_error:
    print(fnf_error)
except AssertionError as error:
    print(error)
    print('Linux linux_interaction() function was not executed')
```
Donde simularemos que podemos cambiar nuestro systema a linux, por lo que si ejecutamos el código nos arrojará lo siguiente:
```ruby
Function can only run on Linux systems.
Linux linux_interaction() function was not executed
```
Esto ocurre debido a que como primero llamamos a la función de linux_interaction(), y en este caso devolvemos un valor falso al consultar si el sistema es linux, entonces, se lanza la excepción assert y se ignora la siguiente línea del bloque try y se pasa directamente al bloque de except que recibe la excepción assert y por lo tanto, se ejecuta el código dentro de este bloque.






