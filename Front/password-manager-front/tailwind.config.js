/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          lightest: '#E0F7FA', // very light blue
          lighter:  '#B2EBF2', // lighter blue
          light:    '#80DEEA', // light blue
          DEFAULT:  '#4DD0E1', // default blue
          dark:     '#26C6DA', // dark blue
        },
      },
    },
  },
  plugins: [],
}

