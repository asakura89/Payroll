<script lang="ts">
    import type { LayoutData } from './$types';
    
    export let data: LayoutData;
</script>

<svelte:head>
    <link href="%sveltekit.assets%/kayo.min.css" rel="stylesheet" type="text/css" />
    <link href="%sveltekit.assets%/site.css" rel="stylesheet" type="text/css" />
    <link href="%sveltekit.assets%/bootstrap.min.css" rel="stylesheet" type="text/css" />
</svelte:head>

<slot />