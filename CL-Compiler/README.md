
# CL Compiler

  

*CL stands for Content Language*

  

From the idea of a CMS for creating websites I wanted to create a kind of scripting language where programmers can implement code and produces valid HTML Code. The project is inspired from PHP but in a much simpler way.

  

**My Goals for the project are:**

1. Create a Variablesystem
2. Have multiple Programming-Type (strings, int)
3. The script language can interpret numeric expression
4. The user can insert comment which are skipped and only visible in the source file
5. The user can use basic statement like `if` or `else`

  

### Project Status 
The Variablesystem and NumericExpression are working. Basic Statements are currently not implement. There is a bug that Variables in HTML Tags are not correctly parsed and resulting in a unexpected behavior.

The project is currently onhold and will probably not be continued due of the cancelation of the CMS Project the language was designed for.


### Example Code
Input `main.cl`:

    {% var int = 55 - 55 - ( 55 + 12 ) %}
    {% var string = "asldfhasdlkfj" %}
	{% var copy = int %}
	/* First comment */

	<p>{{int}}</p>
	<p>{{string}}</p>
	<p>{{5 + 1}}</p>

	/* Second comment */
Line 1: variable assignment with a numericexpression with nested brackets
Line 2: string assignment
Line 3: copying the value of a variable to a new variable (possible feature would be supporting references to other variables)
Line 4 & 10: comment
Line 6 - 8: returning the value of the variable or numeric expression


Output `main.html`: 

    <p>-43</p>
    <p>asldfhasdlkfj</p>
    <p>6</p>


## Installation and Setup Instructions

### Installation:

 1. Clone this repository
 2. Open `CLCompiler.csproj`

### Setup / Configure:

 1. Open file `program.cs`
 2. Adjust `new  Compiler().Compile(@"-your path to the source file-", @"-your path where the output should be generated-"*optional*);`
 3. Call `Compile()` as often as you need
 4. Run Programm

### CL Syntax
*The Tokens need to be seperated with a Whitespace otherwise the Token could be interpreted wrongly.*

Statements begin with `{%` and end with `%}`.
Output-Statements begin with `{{` followed by the statement and end with `}}`.

Variable Assignment:

    {% var yourvariablename = *your expression* %}

String Declaration:

    {% var yourstring = "your content" %}

Numeric Exression:

    {% var youroutput = 5 + 12 * (12 / 6) %}

Valid Operators are: *+, -, /, \** and Brackets can be used to nest numeric expressions.
*Note: Only int operations are currently supported*.

Comment:
Comments begin with `/*` and end with `*/`.

Output the value of a variable:

    <p>{{yourvariablename}}</p>

Output the result of an expression:

    <p>{{5 + 12}}</p>

## Reflection

The project started from my curiosity on how programming languages are functioning. Inspired by Bisqwit and his video on lexer and parser (https://youtu.be/eF9qWbuQLuw) I decided to try it out myself.

I have learned a lot about the structure of programming languages and syntaxes, the difference between programming languages and scripting languages and how to write regular expressions.

I have written my own lexer and parser which can handles statements and expression. 