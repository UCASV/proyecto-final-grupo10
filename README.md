# Proyecto final. MSPAS grupo10

### Aspectos técnicos


Versión del software:v1.0.0 .Net 5.0


Sistemas operativo: Desktop Application, Windows Form Application


Patrón de diseño: Repositorio
Para implementar este patrón de diseño primeramente se crea una interfaz en donde existirán las 4 funciones básicas de manejo del context, obtener todos los datos, agregar, actualizar o remover alguno de estos; luego solo hay que crear sus clases hijas que implementen la interfaz y defina la entidad a la que se le aplicará estos servicios.


El propósito de implementar este patrón de diseño es la facilidad de manejar el context para agregar y consultar las entidades, además de ahorrarnos código al llamar al context para cada botón o función que lo necesitara y en vez de eso solo implementar el constructor de los servicios de la entidad.


Paquete externos:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Estos 3 primeros paquetes fueron instalados ya que son fundamentales para trabajar con Entity Framework y poder conectar con la base de datos, instalamos específicamente Microsoft.EntityFrameworkCore.SqlServer porque esa fue la herramienta que hemos seleccionado para gestionar nuestra base de datos, pero en otros caso también pudo haber sido utilizado Microsoft.EntityFrameworkCore.MySql.


IText7
Este paquete fue instalado para la generación de los pdf de los ciudadanos.


### Instalación


Primero abrimos nuestra carpeta “Instalador”


![image](https://user-images.githubusercontent.com/54814853/123871255-bb3cb280-d8f0-11eb-8877-7f25d1ca12e4.png)



Accedemos a nuestra carpeta “Debug”


![image](https://user-images.githubusercontent.com/54814853/123871291-c7c10b00-d8f0-11eb-959d-642e435ffec1.png)



Abrimos el setup del programa


![image](https://user-images.githubusercontent.com/54814853/123871318-d3143680-d8f0-11eb-80fc-c111b3ad69e7.png)



Debemos continuar y seleccionar la opción, solo para este usuario, continuar y aceptar los siguientes formularios


![image](https://user-images.githubusercontent.com/54814853/123871342-dc050800-d8f0-11eb-9644-fe1030af2f86.png)



![image](https://user-images.githubusercontent.com/54814853/123871352-e1fae900-d8f0-11eb-8846-54605d82ebf3.png)



![image](https://user-images.githubusercontent.com/54814853/123871370-e6bf9d00-d8f0-11eb-898b-937017a13e23.png)



Para el uso de este software es necesario tener una base de datos existente cuyo nombre es “Project” y tiene los datos básicos para poder iniciar el programa, este es implementado con el gestor Sql Server


![image](https://user-images.githubusercontent.com/54814853/123871395-f17a3200-d8f0-11eb-9fb9-2b190da46a31.png)



## Manual de usuario


### Descripción general del proyecto


El proyecto consiste en un software que permite almacenar en una base de datos, la información de las citas de vacunación de los ciudadanos de el salvador, el programa está programado en el lenguaje c# y conectado a su vez a una base de datos en donde se almacena la información de las citas, los gestores, las cabinas, los ciudadanos y otros datos de importancia para la realización del proceso de vacunación del ciudadano.


El programa va dirigido para los gestores en las cabinas de vacunación, para que ellos registren los datos de las citas, tengan a la mano los datos necesarios para el seguimiento de estas, programen las fechas de las citas, tomen dato de los efectos secundarios ocasionados por la vacuna a los ciudadanos y también puedan programar la cita de la segunda dosis.


Además, el programa valida según los datos del ciudadano si estos son aptos para ser vacunados según criterios como su edad, si pertenece a un grupo de prioridad o si posee alguna enfermedad incurable transmisible.
Al finalizar el proceso de inscripción de citas, el programa podrá generar un pdf, el cual se imprimirá y se le entregará al ciudadano para poder presentarse a la cita.



### Funcionamiento del software


Para el uso adecuado de este software los Gestores de cabina tienen acceso, a estos se les proporciona un usuario y una contraseña para tener acceso al manejo del programa y así gestionar las cabinas con mayor facilidad.



### Formulario de inicio


Este es el formulario de inicio de sesión en el cual un gestor tiene que rellenar los campos del formulario con el usuario y la contraseña que se le ha proporcionado. Luego hay que dar click en el botón “Iniciar sesión” para acceder al programa.


![image](https://user-images.githubusercontent.com/54814853/123567867-59f5d180-d780-11eb-87f7-9a58c49774f0.png)


### Formulario Principal


Este es el formulario principal el cual se despliega luego de haber accedido al programa con las credenciales respectivas, en este Formulario se tienen las siguientes opciones: “Proceso de Cita”, “Seguimiento de Cita” y “Segunda Cita”. Para dirigirse a estas opciones solo hace falta dar click en el botón correspondiente.


![image](https://user-images.githubusercontent.com/54814853/123567949-8578bc00-d780-11eb-8e47-fb8311d8b242.png)


### Proceso de Cita


Al acceder en la opción de “Proceso de Cita” se desplegará el siguiente formulario:


![image](https://user-images.githubusercontent.com/54814853/123567999-a0e3c700-d780-11eb-900e-c9b5cef9864a.png)



En este formulario el gestor tendrá que solicitar los datos al ciudadano y rellenarlos en los campos respectivamente y de manera ordenada, una vez el ciudadano haya proporcionado todos los datos se tiene que dar al botón de “Siguiente” y si por accidente el gestor a esta opción el gestor puede regresar al formulario principal con el botón “Cancelar”.  



Al haber dado en el botón “Siguiente” se mostrará la siguiente pregunta que es muy importante tener en cuenta al momento de vacunar a un ciudadano. El gestor tiene que interrogar al ciudadano, preguntándole si posee alguna de estas enfermedades y luego marcar las que el usuario le indique (En el caso que el ciudadano no posea ninguna de ellas solo no hay que dejar todas desmarcadas) y luego el gestor tiene que dar click en el botón “Siguiente”. El botón “Cancelar” también nos redirige al formulario principal.



![image](https://user-images.githubusercontent.com/54814853/123568043-bd7fff00-d780-11eb-9b86-bdfb9332d3fb.png)


Por ultimo se muestra la siguiente ventana la cual nos asignará todos los datos de nuestra cita de vacunación solo hay que dar en el botón “Aceptar” y el ciudadano ya podrá ir a vacunarse.



![image](https://user-images.githubusercontent.com/54814853/123568095-d8527380-d780-11eb-978d-a9799a117e4f.png)


### Seguimiento de Cita


En la opción de “Seguimiento de Cita” el gestor podrá ver la siguiente ventana: 



![image](https://user-images.githubusercontent.com/54814853/123568134-ed2f0700-d780-11eb-9000-2a4221b0d46e.png)


Aquí el gestor debe colocar dentro del campo el número de DUI del ciudadano que solicitó su comprobante y luego dar click en el botón “Generar PDF”. Esto generará el comprobante con todos los datos de la cita del ciudadano en cuestión.


### Segunda Cita


La opción de segunda cita debe hacerse el día que el ciudadano llega a su primera cita en esta opción se agenda la segunda dosis de la vacuna. El gestor tiene que preguntar el número de DUI del cuidado y colocarlo en el campo correspondiente y luego dar click en el botón “Ingresar al paciente”. 


![image](https://user-images.githubusercontent.com/54814853/123568190-0a63d580-d781-11eb-8f6b-63e364ab1552.png)


Luego de ingresar al ciudadano el gestor debe preguntarle si sufrió algún efecto secundario al momento de vacunarse y el tiempo en el cual los comenzó a presentar. El gestor debe marcar todos los efectos secundarios que el paciente mencione y si presenta uno que no está en la ventana debe colocar dicho efecto secundario en el campo de “Otros”, posteriormente se debe indicar en número de minutos en el cual se presentaron dichos efectos. Se debe rellenar el campo vacunador con el nombre del Vacunador del Paciente. Por último el gestor debe dar click en el botón “Registrar dosis”


![image](https://user-images.githubusercontent.com/54814853/123568286-3d0dce00-d781-11eb-87b4-4bbbbd91ee01.png)


Por último se desplegará esta ventana con todos los datos para la segunda dosis de la vacuna, luego de proporcionar los datos al ciudadano el gestor debe dar click en el botón “Aceptar”.


![image](https://user-images.githubusercontent.com/54814853/123568321-4bf48080-d781-11eb-862b-7573187556b7.png)


El programa cerrará esta ventana y se dirigirá al menú principal listo para registrar otro paciente.


### Issues


-Al momento de que un gestor se registre. Que el usuario o contraseña del gestor no coincidan o no existan, para resolver esto el gestor debe consultar sobre los datos correctos con el encargado de la base ya que es un usuario único.


![image](https://user-images.githubusercontent.com/54814853/123568358-66c6f500-d781-11eb-8222-21c20094ea84.png)



-Al momento de registrar a un ciudadano. Que el ciudadano intente registrarse nuevamente si ya está realizando un proceso de vacunación, para resolver esto el gestor deberá informarle que ya está realizando un proceso de vacunación o que el ciudadano verifique que el número de DUI proporcionado sea el correcto (de 10 caracteres y tenga un “-”).


![image](https://user-images.githubusercontent.com/54814853/123568378-734b4d80-d781-11eb-93ae-7db4618ba4f4.png)



-Al momento de registrar a un ciudadano. Que el ciudadano solo haya ingresado un nombre o un abreviado, para resolver esto el gestor debe solicitarle al ciudadano que le proporcione su nombre completo para poder registrarlo (mayor a 10 caracteres)


![image](https://user-images.githubusercontent.com/54814853/123568423-8bbb6800-d781-11eb-9fe0-1228d649cc1d.png)



-Al momento de registrar a un ciudadano. Para este primer periodo de vacunación el software no admitirá el registro de menores de edad, para resolver esto el gestor deberá notificarle esto al ciudadano o solicitar su DUI para comprobar su mayoría de edad.


![image](https://user-images.githubusercontent.com/54814853/123568448-98d85700-d781-11eb-8667-2cffcd6ebdbe.png)



-Al momento de registrar a un ciudadano. Que el ciudadano no haya proporcionado un número de teléfono válido (de 8 dígitos), para resolver esto el gestor debe solicitar que le proporcione de manera adecuada su número telefónico al ciudadano (de 8 dígitos).


![image](https://user-images.githubusercontent.com/54814853/123568473-a7bf0980-d781-11eb-9987-3f4518f4cb1b.png)



-Al momento de registrar a un ciudadano. Que el correo electrónico del ciudadano no contenga un “@” y un “.” Para ingresar una dirección de correo válida, para ello el gestor deberá solicitarle al ciudadano que le proporcione la dirección de correo electrónica correcta con su respectivo “@” y “.”.


![image](https://user-images.githubusercontent.com/54814853/123568493-b3aacb80-d781-11eb-8ff6-5820d4fd9b0e.png)



-Al momento de registrar a un ciudadano. Que el gestor no ingrese la  dirección de vivienda completa del ciudadano, para resolver esto el gestor debe solicitar la dirección de vivienda de manera detallada al ciudadano (debe ser mayor a 10 dígitos).


![image](https://user-images.githubusercontent.com/54814853/123568515-c02f2400-d781-11eb-9b61-e43887691417.png)



-Al momento de registrar a un ciudadano. Que los datos proporcionados por el ciudadano ciudadano no cumplan con ninguno de los requerimientos para pertenecer, entre los que están, ser mayores a 60 años o que sea mayor a 18 años e incluye, pertenecer a una institución esencial que le de la prioridad de vacunación, como lo son las instituciones de salud, fuerza armada, PNC, personal fronterizo y gobierno; o que presente alguna enfermedad no transmisible o discapacidad. Para poder resolver esto el gestor deberá informar al ciudadano que no pertenece a un grupo prioritario a vacunar y deberá esperar un tiempo o reiniciar el proceso y verificar que todos los datos han sido ingresados correctamente.


![image](https://user-images.githubusercontent.com/54814853/123568548-cde4a980-d781-11eb-8471-330153c52811.png)



-Que el DUI del ciudadano del que se desea exportar la información a pdf sea incorrecto o no haya sido registrado, para resolver esto se debe verificar que el DUI del ciudadano se esté ingresando de forma correcta o que el ciudadano requerido ya esté registrado.


![image](https://user-images.githubusercontent.com/54814853/123568579-db9a2f00-d781-11eb-8be8-91c8ba35cac9.png)



-Al iniciar el proceso de vacunación. Que en el proceso de vacunación se intente ingresar a un paciente que ya recibió la primera dosis, para resolver esto se debe verificar que el número de DUI con el que se buscó al ciudadano agendado no haya recibido ya la primera dosis o notificarle que ya fue vacunado y deberá esperar a la cita de la segunda dosis.


![image](https://user-images.githubusercontent.com/54814853/123568605-e94fb480-d781-11eb-8252-11ea2eaf8ce2.png)



-Al iniciar el proceso de vacunación. Que el DUI del ciudadano no se encuentra en la base de datos para si cita de primera dosis, para resolver esto hay que verificar el número de DUI del ciudadano se introdujo de manera correcta o verificar que el ciudadano con ese DUI realmente haya agendado previamente su cita, de no ser así deberá pasar al proceso de primera cita para agendarse.


![image](https://user-images.githubusercontent.com/54814853/123568631-f7053a00-d781-11eb-9048-3293af7a3da4.png)


-Al momento de hacer el seguimiento de cita y exportar el pdf descargando el programa por medio de instalador este muestra un error que interrumpe el programa, para resolver este problema se debe iniciar el programa por medio del ejecutable


![image](https://user-images.githubusercontent.com/54814853/123871591-0c4ca680-d8f1-11eb-9199-e52f68e6ecdf.png)












