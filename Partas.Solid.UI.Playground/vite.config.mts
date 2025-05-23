import { defineConfig } from 'vite'
import solidPlugin from 'vite-plugin-solid';
import tailwindcss from "@tailwindcss/vite";

const repoName = "Partas.Solid.UI.Plaground"

// https://vitejs.dev/config/
export default defineConfig({
    // clearScreen: false,
    server: {
        watch: {
            ignored: [
                "**/*.md" , // Don't watch markdown files
                "**/*.fs" , // Don't watch F# files
                "**/*.fsx"  // Don't watch F# script files
            ]
        }
    },
    base: `/${repoName}/`,
    build: {
        outDir: "output"
    },
    plugins: [
        solidPlugin(),
        tailwindcss(),
    ],
})