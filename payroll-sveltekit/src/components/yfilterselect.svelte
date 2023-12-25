<script>
    import { onMount } from "svelte";
    import chevronDown from "assets/icons/chevron-down-solid.svg";

    export let data;
    export let update;
    export let setMessage;

    let isNoData = false;

    $: {
        if (!data.data) {
            isNoData = false;
        } else {
            for (let i = 0; i < data.data.length; i++) {
                if (data.data[i][data.yData[0].value] !== null) {
                    isNoData = false;
                    break;
                }
                isNoData = true;
            }
        }
    }

    onMount(() => {
        if (isNoData) {
            setMessage("No data can be shown");
        } else {
            setMessage(null);
        }
    });
</script>

<div class="yFilter">
    <select
        class="select"
        on:change={(e) => {
            const yData = [
                data.yDataOption.find((data) => data.value === e.target.value),
            ];
            update({ yData });
        }}
        value={data.yData[0].value || 0}
    >
        {#if data.yDataOption.filter((o) => o.show).length === 0}
            <option>No Filter</option>
        {:else}
            {#each data.yDataOption.filter((o) => o.show) as data, i}
                <option value={data.value}>{data.label}</option>
            {/each}
        {/if}
    </select>
</div>

<style lang="css">
    .yFilter .select {
        background-image: url(chevronDown);

    }

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

    .yFilter {
        margin-right: 20px !important;
    }

    .yFilter .select {
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

    .yFilter .select option[disabled] {
        display: block;
        color: #ccc;
    }

    .yFilter .select:focus,
    .yFilter .select:active {
        outline: 0;
    }

    .yFilter select::-ms-expand {
        display: none;
    }

    @media only screen and (max-width: 768px) {
        .yFilter {
            width: 100%;
            margin-right: 1.5rem;
        }

        .yFilter .select {
            width: 100%;
            margin-right: 0 !important;
            margin-bottom: 8px !important;
        }
    }

</style>
