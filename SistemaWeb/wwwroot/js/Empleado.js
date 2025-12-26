
$(document).ready(function () {
    $('#NuevoModal').on('hidden.bs.modal', function (e) {
        // Establece los valores de los campos de entrada como cadenas vacías
        $('#NombreN').val('');
        $('#ApePaternoN').val('');  
        $('#ApeMaternoN').val('');
        $('#DivisionN').val($('#DivisionN option:first').val());
        $('#PuestoN').val($('#PuestoN option:first').val());
        $('#TipoN').val($('#TipoN option:first').val());
        $('#DepartamentoN').val($('#DepartamentoN option:first').val());
        $('#LocalidadN').val($('#LocalidadN option:first').val());
    });

    var idUsuarios; // Declarar idUsuario fuera de la función de clic del botón

    cargarAlertas();
    var idEmpleadoTemp; // Variable para almacenar temporalmente el valor de IdUsuario

    // Captura el evento click del botón de editar
    $('#datatablesSimple').on('click', '.btn-success', function () {
        var idEmpleado = $(this).data('id'); // Obtén el ID de usuario de la fila seleccionada

        idEmpleadoTemp = idEmpleado; // Almacena el valor de IdUsuario temporalmente

        // Hacer una solicitud AJAX para obtener los datos del usuario
        $.ajax({
            url: '/Empleado/ObtenerEmpleado', // URL de tu controlador que obtiene los datos del usuario
            type: 'GET',
            data: { idEmpleado: idEmpleado }, // Envía el ID de usuario como parámetro
            success: function (response) {
                // Llena los campos del modal con los datos obtenidos +		empleado	ApePaterno = "Morales", ApeMaterno = "Morales"	SistemaWeb.Models.EmpleadoModel

                $('#Nombre').val(response.nombre); // Asigna el valor del nombre
                $('#ApePaterno').val(response.apepaterno); // Asigna el valor del apellido paterno
                $('#ApeMaterno').val(response.apematerno);
                $('#Tipo').val(response.tipo);
                $('#Division').val(response.division);
                $('#Puesto').val(response.puesto);
                $('#Departamento').val(response.departamento);
                $('#Localidad').val(response.localidad);
                $('#Correo').val(response.correo);

                $('#flexSwitchCheckDefault').prop('checked', response.estatus === 1);
                $('#Acceso').prop('checked', response.acceso === 1);
            },
            error: function () {
                alert('Error al obtener los datos del Empleado');
            }
        });
    });

    $('#exampleModal').on('hidden.bs.modal', function () {
        idEmpleadoTemp = null; // Restablece el valor de idUsuarioTemp al cerrar el modal
    });

    $('#btnGuardarCambios').on('click', function () {
        showSpinner();
        var idUsuario = idEmpleadoTemp; // Obtén el valor almacenado en idUsuarioTemp
        var nombre = $('#Nombre').val().trim();
        var apepaterno = $('#ApePaterno').val().trim();
        var apematerno = $('#ApeMaterno').val().trim();
        var tipo = $('#Tipo').val();
        var division = $('#Division').val();
        var puesto = $('#Puesto').val();
        var departamento = $('#Departamento').val();
        var localidad = $('#Localidad').val();
        var estatus = $('#flexSwitchCheckDefault').prop('checked') ? 1 : 0;
        var acceso = $('#Acceso').prop('checked') ? 1 : 0;
        var correo = $('#Correo').val().trim();


        if (nombre === '' || apepaterno === '' || apematerno === '' || correo === '') {

            mostrarAlerta3('danger', 'Por favor, completa todos los campos.');
            hideSpinner();
            return;
        }
        else if (division === null) {
            mostrarAlerta3('danger', 'Por favor, selecciona una división.');
            hideSpinner();
            return;
        }
        else if (puesto === null) {
            mostrarAlerta3('danger', 'Por favor, selecciona un puesto.');
            hideSpinner();
            return;
        }
        else if (departamento === null) {
            mostrarAlerta3('danger', 'Por favor, selecciona un departamento.');
            hideSpinner();
            return;
        }
        else if (localidad === null) {
            mostrarAlerta3('danger', 'Por favor, selecciona una localidad.');
            hideSpinner();
            return;
        }
        else if (tipo === null) {
            mostrarAlerta3('danger', 'Por favor, selecciona un tipo.');
            hideSpinner();
            return;
        }

        // Hacer una solicitud AJAX para actualizar los datos del usuario
        $.ajax({
            url: '/Empleado/ActualizarEmpleado', // URL de tu controlador para actualizar usuario
            type: 'POST',
            data: {
                Id_Empleado: idUsuario, // Corrige el nombre del campo aquí
                Nombre: nombre,
                Apepaterno: apepaterno,
                Apematerno: apematerno,
                Tipo:tipo,
                Division: division,
                Puesto: puesto,
                Departamento: departamento,
                Localidad :localidad,
                Estatus: estatus,
                Acceso: acceso,
                Correo: correo
            },
            success: function (response) {
                if (response.success) {
                    guardarAlertaEnAlmacenamiento('success', response.message);
                    window.location.reload();

                    // Restablecer los campos del formulario
                    $('#Correo').val('');
                    $('#Nombre').val('');
                    $('#ApePaterno').val('');
                    $('#ApeMaterno').val('');
                    $('#Tipo').val($('#Tipo option:first').val());
                    $('#Division').val($('#Division option:first').val());
                    $('#Puesto').val($('#Puesto option:first').val());
                    $('#Departamento').val($('#Departamento option:first').val());
                    $('#Localidad').val($('#Localidad option:first').val());
                    // Eliminar la alerta después de un tiempo
                    setTimeout(function () {
                        successAlert.remove();

                    }, 5000); // Eliminar la alerta después de 3 segundos
                    actualizarTablaUsuarios();
                } else {
                    guardarAlertaEnAlmacenamiento('danger', response.message);
                    window.location.reload();
                }
            },
            error: function () {
                guardarAlertaEnAlmacenamiento('danger', 'Error Con el servidor');
                window.location.reload();
            },
            complete: function () {
            }
        });

    });
    //nf
});

function mostrarAlerta3(tipo, mensaje) {
    var alerta = $('<div class="alert alert-danger alert-dismissible fade show" role="alert ">' +
        mensaje +
        '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>' +
        '</div>');
    $('#alertita2').prepend(alerta);

    // Eliminar la alerta después de 5 segundos
    setTimeout(function () {
        alerta.alert('close');
    }, 5000);
}
function mostrarAlerta2(tipo, mensaje) {
    var alerta = $('<div class="alert alert-danger alert-dismissible fade show" role="alert ">' +
        mensaje +
        '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>' +
        '</div>');
    $('#alertita').prepend(alerta);

    // Eliminar la alerta después de 5 segundos
    setTimeout(function () {
        alerta.alert('close');
    }, 5000);
}

function mostrarAlerta(tipo, mensaje) {
    var toast = $('<div class="toast align-items-center text-white bg-' + tipo + ' border-0" role="alert" aria-live="assertive" aria-atomic="true">' +
        '<div class="d-flex">' +
        '<div class="toast-body">' + mensaje + '</div>' +
        '<button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>' +
        '</div>' +
        '</div>');

    $('#liveToastContainer').append(toast);

    var bsToast = new bootstrap.Toast(toast[0]);
    bsToast.show();

    // Eliminar el toast después de 5 segundos
    setTimeout(function () {
        bsToast.hide();
    }, 5000);
}



// Función para guardar la alerta en el almacenamiento local del navegador
function guardarAlertaEnAlmacenamiento(tipo, mensaje) {
    var alertasGuardadas = JSON.parse(localStorage.getItem('alertas')) || [];
    alertasGuardadas.push({ tipo: tipo, mensaje: mensaje });
    localStorage.setItem('alertas', JSON.stringify(alertasGuardadas));
}

// Función para cargar las alertas almacenadas y mostrarlas en la página
function cargarAlertas() {
    var alertasGuardadas = JSON.parse(localStorage.getItem('alertas')) || [];
    alertasGuardadas.forEach(function (alerta) {
        mostrarAlerta(alerta.tipo, alerta.mensaje);
    });
    localStorage.removeItem('alertas'); // Eliminar las alertas después de mostrarlas
}

document.addEventListener('DOMContentLoaded', function () {
    // Obtener referencias a los select
    const selectPuesto = document.getElementById('PuestoN');
    const selectDepartamento = document.getElementById('DepartamentoN');

    // Escuchar el evento de cambio en el select de puesto
    selectPuesto.addEventListener('change', function () {
        // Obtener el ID de departamento seleccionado en el select de puesto
        const idDepartamentoSeleccionado = this.options[this.selectedIndex].dataset.segundoIdentificador;

        // Recorrer las opciones del select de departamento
        for (let option of selectDepartamento.options) {
            // Comparar el valor de la opción con el ID de departamento seleccionado
            if (option.value === idDepartamentoSeleccionado) {
                // Seleccionar automáticamente la opción correspondiente
                option.selected = true;
                break;  // Terminar el bucle una vez que se encuentre la coincidencia
            }
        }

        // Verificar si el ID de puesto seleccionado es 1002
        if (this.value === '1002') {
            // Habilitar el select de departamento
            selectDepartamento.disabled = false;

            // Recorrer las opciones del select de departamento
            for (let option of selectDepartamento.options) {
                // Comparar el valor de la opción con el ID de departamento seleccionado
                if (option.value === idDepartamentoSeleccionado) {
                    // Seleccionar automáticamente la opción correspondiente
                    option.selected = true;
                    break;  // Terminar el bucle una vez que se encuentre la coincidencia
                }
            }
        } else {
            // Si el puesto seleccionado no es 1002, deshabilitar el select de departamento
            selectDepartamento.disabled = true;
        }
    });
});



document.addEventListener('DOMContentLoaded', function () {
    // Obtener referencias a los select
    const selectPuesto = document.getElementById('Puesto');
    const selectDepartamento = document.getElementById('Departamento');

    // Escuchar el evento de cambio en el select de puesto
    selectPuesto.addEventListener('change', function () {
        // Obtener el ID de departamento seleccionado en el select de puesto
        const idDepartamentoSeleccionado = this.options[this.selectedIndex].dataset.segundoIdentificador;

        // Recorrer las opciones del select de departamento
        for (let option of selectDepartamento.options) {
            // Comparar el valor de la opción con el ID de departamento seleccionado
            if (option.value === idDepartamentoSeleccionado) {
                // Seleccionar automáticamente la opción correspondiente
                option.selected = true;
                break;  // Terminar el bucle una vez que se encuentre la coincidencia
            }
        }

        // Verificar si el ID de puesto es igual a 1002 para habilitar el select de departamento
        if (selectPuesto.value === '1002') {
            selectDepartamento.removeAttribute('disabled');
        }
    });

    // Escuchar el evento de cambio en el select de departamento
    selectDepartamento.addEventListener('change', function () {
        // Obtener el ID del departamento seleccionado
        const idDepartamentoSeleccionado = this.value;
        console.log("ID del departamento seleccionado:", idDepartamentoSeleccionado);
    });
});

$('#btnGuardarCambiosN').on('click', function () {
    showSpinner();
    var nombre = $('#NombreN').val().trim();
    var apePaterno = $('#ApePaternoN').val().trim();
    var apeMaterno = $('#ApeMaternoN').val().trim();
    var tipo = obtenerIdTipo();
    var division = obtenerIdDivision();
    var puesto = obtenerIdPuesto(); // Obtener el valor de IdPuesto
    var departamento = obtenerIdDepartamento();
    var localidad = obtenerIdLocalidad();
    var estatus = $('#flexSwitchCheckDefaultN').prop('checked') ? 1 : 0;
    var acceso = $('#AccesoN').prop('checked') ? 1 : 0;


    if (nombre === '' || apePaterno === '' || apeMaterno === '') {

        mostrarAlerta2('danger', 'Por favor, completa todos los campos.');
        hideSpinner();
        return;
    }
     if (division === null) {
        mostrarAlerta2('danger', 'Por favor, selecciona una división.');
        hideSpinner();
        return;
    }
    if (puesto === null) {
        mostrarAlerta2('danger', 'Por favor, selecciona un puesto.');
        hideSpinner();
        return;
    }
     if (departamento === null) {
        mostrarAlerta2('danger', 'Por favor, selecciona un departamento.');
        hideSpinner();
        return;
    }
     if (localidad === null) {
        mostrarAlerta2('danger', 'Por favor, selecciona una localidad.');
        hideSpinner();
        return;
    }
    if (tipo === null) {
        mostrarAlerta2('danger', 'Por favor, selecciona un tipo.');
        hideSpinner();
        return;
    }

    // Función para obtener el valor de IdPuesto
    function obtenerIdPuesto() {
        var selectPuesto = $('#PuestoN');
        return selectPuesto.val();
    }

    function obtenerIdDepartamento() {
        var selectDepartamento = $('#DepartamentoN');
        return selectDepartamento.val();
    }

    function obtenerIdLocalidad() {
        var selectLocalidad = $('#LocalidadN');
        return selectLocalidad.val();
    }

    function obtenerIdDivision() {
        var selectDivision = $('#DivisionN');
        return selectDivision.val();
    }

    function obtenerIdTipo() {
        var selectTipo = $('#TipoN');
        return selectTipo.val();
    }

    var datos = {
        Nombre: nombre,
        ApePaterno: apePaterno,
        ApeMaterno: apeMaterno,
        Tipo:tipo,
        Division: division,
        Puesto: puesto,
        Departamento: departamento,
        Localidad: localidad,
        Estatus: estatus,
        Acceso:acceso
    };

    $.ajax({
        url: '/Empleado/Guardar',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos),
        success: function (response) {
            if (response.success) {
                guardarAlertaEnAlmacenamiento('success', response.message);
                setTimeout(function () {
                    window.location.reload();
                }, 3000); // Recargar la página después de 3 segundos
            } else {
                guardarAlertaEnAlmacenamiento('danger', response.message);
            }
        },
        error: function () {
            guardarAlertaEnAlmacenamiento('danger', 'Error al conectar con el servidor');
            
        }
       
    });

});


// Función para mostrar el preloader
function showSpinner() {
    $('.preloader').show();
}

// Función para ocultar el preloader
function hideSpinner() {
    $('.preloader').hide();
}

document.addEventListener("DOMContentLoaded", function () {
    // Ocultar el preloader después de que la página se haya cargado completamente
    hidePreloader();
});

// Función para ocultar el preloader
function hidePreloader() {
    document.querySelector(".preloader").style.display = "none";
}


/*VALIDACIONES DE LOS CAMPOS DE TEXTO*/

$('#NombreN').keyup(function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ ]+/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 20) {
        cleanedValue = cleanedValue.substring(0, 20);
    }

    this.value = cleanedValue;
});

$('#NombreN').on('blur', function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ ]+/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 20) {
        cleanedValue = cleanedValue.substring(0, 20);
    }

    this.value = cleanedValue;
});


$('#ApePaternoN').keyup(function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});

$('#ApePaternoN').on('blur', function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});


$('#ApeMaternoN').keyup(function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});

$('#ApeMaternoN').on('blur', function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});

$('#Nombre').keyup(function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ ]+/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 20) {
        cleanedValue = cleanedValue.substring(0, 20);
    }

    this.value = cleanedValue;
});

$('#Nombre').on('blur', function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ ]+/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 20) {
        cleanedValue = cleanedValue.substring(0, 20);
    }

    this.value = cleanedValue;
});


$('#ApePaterno').keyup(function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});

$('#ApePaterno').on('blur', function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});


$('#ApeMaterno').keyup(function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});

$('#ApeMaterno').on('blur', function () {
    // Eliminar caracteres no permitidos
    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

    // Limitar a 10 caracteres
    if (cleanedValue.length > 15) {
        cleanedValue = cleanedValue.substring(0, 15);
    }

    this.value = cleanedValue;
});