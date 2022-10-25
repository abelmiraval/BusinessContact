<template>

    <div class="container flex justify-center mx-auto">
        <div class="flex flex-col">
            <div class="w-full">
                <div class="border-b border-gray-200 shadow">
                    <table>
                        <thead class="bg-gray-50">
                            <tr>
                                <th class="px-6 py-2 text-xs text-gray-500">
                                    Codigo
                                </th>
                                <th class="px-6 py-2 text-xs text-gray-500">
                                    Nombre
                                </th>
                                <th class="px-6 py-2 text-xs text-gray-500">
                                    Celular
                                </th>
                                <th class="px-6 py-2 text-xs text-gray-500">
                                    Fecha de registro
                                </th>
                                <th class="px-6 py-2 text-xs text-gray-500">
                                    Edit
                                </th>
                                <th class="px-6 py-2 text-xs text-gray-500">
                                    Delete
                                </th>
                            </tr>
                        </thead>
                        <tbody class="bg-white">
                            <tr class="whitespace-nowrap" v-for="(item, index) in contacts" :key="index">
                                <td class="px-6 py-4 text-sm text-gray-500">
                                    {{index + 1}}
                                </td>
                                <td class="px-6 py-4">
                                    <div class="text-sm text-gray-900">
                                        {{item.name}}
                                    </div>
                                </td>
                                <td class="px-6 py-4">
                                    <div class="text-sm text-gray-500">{{item.phone}}</div>
                                </td>
                                <td class="px-6 py-4 text-sm text-gray-500">
                                    {{item.date}}
                                </td>
                                <td class="px-6 py-4">
                                    <a href="#" class="px-4 py-1 text-sm text-white bg-blue-400 rounded">Editar</a>
                                </td>
                                <td class="px-6 py-4">
                                    <a href="#" class="px-4 py-1 text-sm text-white bg-red-400 rounded">Eliminar</a>
                                </td>
                            </tr>
   
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import axios from 'axios'
    export default {
        name: 'HelloWorld',
        data() {
            return {
                contacts: []
            }
        },
        created(){
            this.fetchUsers();
        },
        methods: {
             fetchUsers: function () {
                const baseURI = 'https://localhost:44309/api/contacts'
                axios.get(baseURI)
                    .then((data) => {
                        this.contacts = data.data.result;
                        console.log(this.contacts);
                    })
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
