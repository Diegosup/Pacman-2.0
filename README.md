# Pacman-2.0

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




