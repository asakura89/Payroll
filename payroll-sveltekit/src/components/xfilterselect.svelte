<!-- XFilterSelect.svelte -->
<script>
    import chevronDown from "assets/icons/chevron-down-solid.svg";

    export let data;
    export let options;
    export let updateData;
    export let updateOptions;

    function handleChange(e) {
        const { xAxes } = options.scales;
        const { xTick } = options.tick;
        const { calendarData } = data;

        const xDataTarget = data.xDataUrl.find(
            (xData) => xData.value === e.target.value,
        );

        xAxes[0].scaleLabel.labelString = xDataTarget.text;
        xTick.formatter = xDataTarget.format;
        calendarData.showBy = xDataTarget.showBy;

        updateOptions({
            scales: {
                ...options.scales,
                xAxes,
            },
            tick: {
                ...options.tick,
                xTick,
            },
        });

        updateData({
            calendarData,
            uploadUrl: xDataTarget.value,
        });
    }
</script>

<div class="xFilter">
    <select
        class="select"
        style="background-image: url({chevronDown})"
        value={data.uploadUrl}
        on:change={handleChange}
    >
        {#each data.xDataUrl as xData, i}
            <option value={xData.value}>{xData.label}</option>
        {/each}
    </select>
</div>

<style lang="scss">
    :root {
        --blue: #012d6c;
        --blue-2: #08457e;
        --grey: #f2f2f2;
        --black: #4a4a4a;
        --light-red: #ffdfd1;
        --red: #ff4136;
        --light-green: #e0ffbe;
        --green: #0e940c;
        --light-gold: #c29c63;
        --gold: #8d7249;
        --dark-blue: #002149;
        --transparent-blue: rgba(1, 45, 108, 0.2);
    }

    .xFilter {
        margin-right: 20px !important;
    }
    .xFilter select.select {
        font: inherit;
        font-size: 16px;
        min-width: 180px;
        border: 1px solid #b6b6b6;
        height: 42px;
        padding: 0 32px 0 12px;
        -webkit-appearance: none;
        margin-bottom: 20px !important;
        background: var(--grey);
        background-position: calc(100% - 12px) center;
        background-size: 12px 13.7px;
        background-repeat: no-repeat;
    }
    .xFilter select.select option[disabled] {
        display: block;
        color: #ccc;
    }
    .xFilter select.select:focus,
    .xFilter select.select:active {
        outline: 0;
    }
    .xFilter select::-ms-expand {
        display: none;
    }

    @media only screen and (max-width: 768px) {
        .xFilter {
            width: 100%;
            margin-right: 1.5rem !important;
        }
        .xFilter select.select {
            width: 100%;
            margin-right: 0 !important;
            margin-bottom: 8px !important;
        }
    }
</style>
