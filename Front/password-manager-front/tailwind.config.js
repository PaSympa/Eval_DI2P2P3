/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          lightest: '#EDE9FE', // very light purple
          lighter:  '#DDD6FE', // lighter purple
          light:    '#C4B5FD', // light purple
          DEFAULT:  '#A78BFA', // default purple
          dark:     '#8B5CF6', // dark purple
        },
      },
    },
  },
  plugins: [],
}

