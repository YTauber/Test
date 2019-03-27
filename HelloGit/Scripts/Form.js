$(() => {

    let x = 0;

    $("#add").on('click', function () {

        x++;

        $(".row").append(`
            <br />
            <div class="col-md-5">
            <input id="f${x}" class="form-control" type="text" name="people[${x}].firstname" placeholder="First Name" />
            </div >
            <div class="col-md-5">
                <input id="l${x}" class="form-control" type="text" name="people[${x}].lastname" placeholder="Last Name" />
            </div>
            <div class="col-md-2">
                <input id="a${x}" class="form-control" type="text" name="people[${x}].age" placeholder="Age" />
            </div>
            <br />
                        `)

        $("#submit").prop("disabled", !checkValidity());

    })

    $("form").on('change', function () {

        $("#submit").prop("disabled", !checkValidity());

    })

    function checkValidity() {

        for (let i = 0; i <= x; i++) {

            let a = $(`#f${i}`).val();
            let b = $(`#l${i}`).val();
            let c = $(`#a${i}`).val();

            if (!a || !b || !c) {

                return false;
            }
        }

        return true;
    }

})