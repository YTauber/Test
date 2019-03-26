$(() => {

    let x = 1

    $("#add").on('click', function () {

        $(".row").append(`
            <br />
            <div class="col-md-5">
            <input class="form-control" type="text" name="people[${x}].firstname" placeholder="First Name" />
            </div >
            <div class="col-md-5">
                <input class="form-control" type="text" name="people[${x}].lastname" placeholder="Last Name" />
            </div>
            <div class="col-md-2">
                <input class="form-control" type="text" name="people[${x}].age" placeholder="Age" />
            </div>
            <br />
                        `)

        x++;

    })

})