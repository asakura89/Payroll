<script lang="ts">
    import type { LayoutData } from './$types';
    
    export let data: LayoutData;
</script>

<svelte:head>
    <!-- <link href="%sveltekit.assets%/assets/kayo.min.css" rel="stylesheet" type="text/css" />
    <link href="%sveltekit.assets%/assets/site.css" rel="stylesheet" type="text/css" />
    <link href="%sveltekit.assets%/assets/bootstrap.min.css" rel="stylesheet" type="text/css" /> -->
    <link href="/assets/kayo.min.css" rel="stylesheet" type="text/css" />
    <link href="/assets/site.css" rel="stylesheet" type="text/css" />
    <link href="/assets/bootstrap.min.css" rel="stylesheet" type="text/css" />
</svelte:head>

<slot />