<script setup>
    import { ref } from 'vue'

    const totalTips = ref(1000)
    const employees = ref(5)
    const result = ref(null)

    async function calculate() {
        try {
            const response = await fetch(
                `http://localhost:5067/tips?totalTips=${totalTips.value}&employees=${employees.value}`
            )

            const data = await response.json()
            result.value = data
        } catch (error) {
            alert('Ошибка подключения к серверу')
            console.error(error)
        }
    }
</script>

<template>
    <h1>Учёт чаевых</h1>

    <div>
        <p>Сумма чаевых:</p>
        <input v-model="totalTips" type="number" />
    </div>

    <div>
        <p>Количество сотрудников:</p>
        <input v-model="employees" type="number" />
    </div>

    <br />

    <button @click="calculate">Рассчитать</button>

    <h2 v-if="result !== null">
        Каждый сотрудник получит: {{ result }}
    </h2>
</template>