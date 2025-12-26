

$(document).ready(function () {
    var idUsuarios; // Declarar idUsuario fuera de la función de clic del botón

    console.log("ID de Usuario:", idUsuarios);
    cargarAlertas();
    var idUsuarioTemp; // Variable para almacenar temporalmente el valor de IdUsuario

    // Captura el evento click del botón de editar
    $('#datatablesSimple').on('click', '.btn-success', function () {
        showSpinner();
        var idUsuario = $(this).data('id'); // Obtén el ID de usuario de la fila seleccionada
        console.log("ID de usuario obtenido:", idUsuario); // Verifica si se está obteniendo el ID correctamente

        idUsuarioTemp = idUsuario; // Almacena el valor de IdUsuario temporalmente

        // Hacer una solicitud AJAX para obtener los datos del usuario
        $.ajax({
            url: '/Usuarios/ObtenerUsuario', // URL de tu controlador que obtiene los datos del usuario
            type: 'GET',
            data: { idUsuario: idUsuario }, // Envía el ID de usuario como parámetro
            success: function (response) {
                hideSpinner();
                // Llena los campos del modal con los datos obtenidos
                $('#Correo').val(response.correo);
                $('#Contrasena').val(response.contrasena);
                $('#flexSwitchCheckDefault').prop('checked', response.estatus === 1);
            },
            error: function () {
                alert('Error al obtener los datos del usuario');
            }
        });
    });

    $('#exampleModal').on('hidden.bs.modal', function () {
        idUsuarioTemp = null; // Restablece el valor de idUsuarioTemp al cerrar el modal
    });

    $('#btnGuardarCambios').on('click', function () {
        showSpinner();
        var idUsuario = idUsuarioTemp; // Obtén el valor almacenado en idUsuarioTemp
        var correo = $('#Correo').val();
        var contrasena = $('#Contrasena').val();
        var estatus = $('#flexSwitchCheckDefault').prop('checked') ? 1 : 0;
        if (correo === '' || contrasena === '') {

            mostrarAlerta2('danger', 'Por favor, completa todos los campos.');
            hideSpinner();
            return;
        }
        // Hacer una solicitud AJAX para actualizar los datos del usuario
        $.ajax({
            url: '/Usuarios/ActualizarUsuario', // URL de tu controlador para actualizar usuario
            type: 'POST',
            data: {
                Id_Usuario: idUsuario, // Corrige el nombre del campo aquí
                Correo: correo,
                Contrasena: contrasena,
                Estatus: estatus
            },
            success: function (response) {
                if (response.success) {
                    guardarAlertaEnAlmacenamiento('success', response.message);
                    window.location.reload();

                    // Restablecer los campos del formulario
                    $('#Correo').val('');
                    $('#Contrasena').val('');
                    $('#flexSwitchCheckDefault').prop('checked', false);

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

//$('#Contrasena').keyup(function () {
//    // Eliminar caracteres no permitidos
//    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

//    // Limitar a 10 caracteres
//    if (cleanedValue.length > 15) {
//        cleanedValue = cleanedValue.substring(0, 15);
//    }

//    this.value = cleanedValue;
//});

//$('#Contrasena').on('blur', function () {
//    // Eliminar caracteres no permitidos
//    var cleanedValue = (this.value + '').replace(/[^A-Za-zÁÉÍÓÚáéíóúÜüÑñ]/g, '');

//    // Limitar a 10 caracteres
//    if (cleanedValue.length > 15) {
//        cleanedValue = cleanedValue.substring(0, 15);
//    }

//    this.value = cleanedValue;
//});


//$('#Correo').keyup(function () {
//    // Eliminar caracteres no permitidos
//    var cleanedValue = (this.value + '').replace(/^[^\s@]+@[^\s@]+\.[^\s@]+$/g, '');

//    // Limitar a 10 caracteres
//    if (cleanedValue.length > 15) {
//        cleanedValue = cleanedValue.substring(0, 15);
//    }

//    this.value = cleanedValue;
//});

//$('#Correo').on('blur', function () {
//    // Eliminar caracteres no permitidos
//    var cleanedValue = (this.value + '').replace(/^[^\s@]+@[^\s@]+\.[^\s@]+$/g, '');

//    // Limitar a 10 caracteres
//    if (cleanedValue.length > 15) {
//        cleanedValue = cleanedValue.substring(0, 15);
//    }

//    this.value = cleanedValue;
//});